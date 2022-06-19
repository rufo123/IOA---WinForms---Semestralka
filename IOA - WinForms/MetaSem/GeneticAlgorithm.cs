using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace IOA___WinForms.MetaSem
{
    class GeneticAlgorithm
    {
        private List<int> aSolution;

        private Dictionary<int, MetaNode> aDictionaryNodes;

        private double aHH;

        private int aMaxPopulations;

        private int t;

        private int n;

        Random rnd = new Random();

        private Selector aSelector;

        private Crossover aCrossover;

        private Mutator aMutator;

        private Evaluator aEvaluator;
        
        private List<List<int>> aPopulation;

        private SortedList<double, List<int>> aElitePopulations;

        private int aElitePopulationsSize;

        private List<int> aBestPopulation;

        private double aBestPopulationHH;

        private int aStartNode;

        private int aEndNode;

        public double HH
        {
            get => aHH;
            set => aHH = value;
        }

        public int T
        {
            get => t;
            set => t = value;
        }

        public int N
        {
            get => n;
            set => n = value;
        }

        public int ElitePopulationsSize
        {
            get => aElitePopulationsSize;
            set => aElitePopulationsSize = value;
        }

        public int StartNode
        {
            get => aStartNode;
            set => aStartNode = value;
        }

        public int EndNode
        {
            get => aEndNode;
            set => aEndNode = value;
        }

        public GeneticAlgorithm(List<int> parSolution, Dictionary<int, MetaNode> parNodes, int parNumberOfRepeats)
        {

            aStartNode = 5;

            aEndNode = 350;

            aSelector = new Selector();

            aCrossover = new Crossover();

            aMutator = new Mutator();

            aEvaluator = new Evaluator();

            aSolution = parSolution;

            aDictionaryNodes = parNodes;

            HH = MetaMain.CalculateRouteCost(parSolution, parNodes);

            aMaxPopulations = 20;

            aElitePopulationsSize = 20;

            aPopulation = new List<List<int>>(aMaxPopulations);

            aElitePopulations = new SortedList<double, List<int>>();

            aBestPopulation = new List<int>();

            N = parNumberOfRepeats;

            GeneratePopulation();

            DoWork();

        }

        public void DoWork()
        {

            aPopulation.Sort((a, b) => MetaMain.CalculateRouteCost(a, aDictionaryNodes).CompareTo(MetaMain.CalculateRouteCost(b, aDictionaryNodes)));
            HH = aEvaluator.Cost(aPopulation[0], aDictionaryNodes);

            Debug.WriteLine("Genetic Start");
            Debug.WriteLine("Old Best Cost:" + HH);

            aBestPopulationHH = Double.MaxValue;

            int tmpRepeatsCount = 0;
            
            while (t <= n && tmpRepeatsCount < n)
            {
                aPopulation.Sort((a, b) => MetaMain.CalculateRouteCost(a, aDictionaryNodes).CompareTo(MetaMain.CalculateRouteCost(b, aDictionaryNodes)));

                List<List<int>> yNova = new List<List<int>>();

                double tmpCalculatedHH = aEvaluator.Cost(aPopulation[0], aDictionaryNodes);

                if (aBestPopulationHH > tmpCalculatedHH)
                {
                    aBestPopulationHH = tmpCalculatedHH;
                    aBestPopulation = aPopulation[0];
                }

                int m = 0;

                while (m < aMaxPopulations)
                {

                   

                    List<int> tmpParents = aSelector.Fitness(aPopulation, aDictionaryNodes);

                    int tmpFirstParent = tmpParents[0];
                    int tmpSecondParent = tmpParents[1];

                    MetaMain.ContinuityChecker(aPopulation[tmpFirstParent]);
                    MetaMain.ContinuityChecker(aPopulation[tmpSecondParent]);

                    List<List<int>> tmpNew = aCrossover.ToCross(aPopulation[tmpFirstParent], aPopulation[tmpSecondParent]);

                    aMutator.Mutate(tmpNew[0]);
                    aMutator.Mutate(tmpNew[1]);

                    if (aEvaluator.Cost(tmpNew[0], aDictionaryNodes) < aEvaluator.Cost(tmpNew[1], aDictionaryNodes))
                    {
                        yNova.Add(tmpNew[0]);
                    }
                    else
                    {
                        yNova.Add(tmpNew[1]);
                    }

                    if (aEvaluator.Cost(tmpNew[tmpNew.Count - 1], aDictionaryNodes) < HH)
                    {
                        HH = aEvaluator.Cost(tmpNew[tmpNew.Count - 1], aDictionaryNodes);
                        t = 0;
                    }

                    m++;
                }

                aPopulation.Sort((a, b) => MetaMain.CalculateRouteCost(a, aDictionaryNodes).CompareTo(MetaMain.CalculateRouteCost(b, aDictionaryNodes)));
                AddToElitePopulation(aPopulation[0]);

                aPopulation.Clear();

                for (int i = 0; i < yNova.Count; i++)
                {
                    aPopulation.Add(yNova[i]);
                }
                
                t++;
                tmpRepeatsCount++;
            }
            
            HH = aEvaluator.Cost(aPopulation[0], aDictionaryNodes);
            Debug.WriteLine(HH);

            PrintResults();


        }

        public void PrintResults()
        {
            string tmpIDs = aDictionaryNodes[aStartNode].Id.ToString();
            string tmpNames = aDictionaryNodes[aStartNode].Name;
            string tmpPos = aDictionaryNodes[aStartNode].Position.ToString();

            for (int i = 0; i < aBestPopulation.Count; i++)
            {
                tmpIDs += " - " + aDictionaryNodes[aBestPopulation[i]].Id;
                tmpNames += " - " + aDictionaryNodes[aBestPopulation[i]].Name;
                tmpPos += " - " + aDictionaryNodes[aBestPopulation[i]].Position;

            }

            tmpIDs += " - " + aDictionaryNodes[aStartNode].Id;
            tmpNames += " - " + aDictionaryNodes[aStartNode].Name;
            tmpPos += " - " + aDictionaryNodes[aStartNode].Position;

            Debug.WriteLine(@"Best UF: " + aBestPopulationHH);
            Debug.WriteLine("Route - IDs: " + tmpIDs);
            Debug.WriteLine("Route - NAMEs: " + tmpNames);
            Debug.WriteLine("Route - POSITIONs: " + tmpPos);

        }

        public void GeneratePopulation()
        {
            for (int i = 0; i < aMaxPopulations; i++)
            {
                 List<int> tmpList = Enumerable.Range(1, aSolution.Count).OrderBy(c => rnd.Next()).ToList();

                 tmpList.Remove(aStartNode);

                 aPopulation.Add(tmpList);

            }
        }

        public void AddToElitePopulation(List<int> parPopulation)
        {
            double tmpPopulationToAddCost = MetaMain.CalculateRouteCost(parPopulation, aDictionaryNodes);
            if (!aElitePopulations.ContainsKey(tmpPopulationToAddCost))
            {
                aElitePopulations.Add(tmpPopulationToAddCost, parPopulation);
            }

            if (aElitePopulations.Count == aElitePopulationsSize)
            {
                aElitePopulations.RemoveAt(aElitePopulationsSize - 1);
            }
        }
    }
}
