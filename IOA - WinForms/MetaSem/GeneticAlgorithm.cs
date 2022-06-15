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


        public GeneticAlgorithm(List<int> parSolution, Dictionary<int, MetaNode> parNodes)
        {
            aSelector = new Selector();

            aCrossover = new Crossover();

            aMutator = new Mutator();

            aEvaluator = new Evaluator();

            aSolution = parSolution;

            aDictionaryNodes = parNodes;

            HH = MetaMain.CalculateRouteCost(parSolution, parNodes);

            aMaxPopulations = 20;

            aPopulation = new List<List<int>>(aMaxPopulations);

            GeneratePopulation();

            DoWork();
        }

        public void DoWork()
        {

            aPopulation.Sort((a, b) => MetaMain.CalculateRouteCost(a, aDictionaryNodes).CompareTo(MetaMain.CalculateRouteCost(b, aDictionaryNodes)));
            HH = aEvaluator.Cost(aPopulation[0], aDictionaryNodes);
            Debug.WriteLine(HH);
            
            while (t <= n)
            {
                aPopulation.Sort((a, b) => MetaMain.CalculateRouteCost(a, aDictionaryNodes).CompareTo(MetaMain.CalculateRouteCost(b, aDictionaryNodes)));

                List<List<int>> yNova = new List<List<int>>();

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

                aPopulation.Clear();

                for (int i = 0; i < yNova.Count; i++)
                {
                    aPopulation.Add(yNova[i]);
                }
                
                t++;
            }
            
            HH = aEvaluator.Cost(aPopulation[0], aDictionaryNodes);
            Debug.WriteLine(HH);


        }

        public void GeneratePopulation()
        {
            for (int i = 0; i < aMaxPopulations; i++)
            {
                 List<int> tmpList = Enumerable.Range(1, aSolution.Count).OrderBy(c => rnd.Next()).ToList();

                 aPopulation.Add(tmpList);

                 Debug.WriteLine(MetaMain.CalculateRouteCost(tmpList, aDictionaryNodes));
            }
        }
    }
}
