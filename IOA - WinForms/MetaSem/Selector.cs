using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace IOA___WinForms.MetaSem
{
    class Selector
    {
        private Random aRandomFirst;
        private Random aRandomSecond;

        private Random aRandomPressureGenerator;

        private Random aRandomUniformRGenerator;

        public Selector()
        {
            aRandomFirst = new Random();
            aRandomSecond = new Random();
            aRandomPressureGenerator = new Random();
            aRandomUniformRGenerator = new Random();
        }

        public List<int> Fitness(List<List<int>> parPopulation, Dictionary<int, MetaNode> parDictionaryNodes)
        {

            List<int> tmpChosenList = new List<int>();

            List<double> tmpFitnesses = new List<double>();

            List<double[]> tmpProbabilities = new List<double[]>();

            List<double> tmpRouteCosts = new List<double>();

            parPopulation.Sort((a, b) => MetaMain.CalculateRouteCost(a, parDictionaryNodes).CompareTo(MetaMain.CalculateRouteCost(b, parDictionaryNodes)));

           // parPopulation.Reverse();

            List<int> tmpKChosenOne = parPopulation[parPopulation.Count - 1];

          

            for (int i = 0; i < parPopulation.Count; i++)
            {
                int tmpHHOfChosenOne = 460; // Toto je to Mko... Malo to byt poradie?

                double tmpFi = aRandomPressureGenerator.NextDouble() * (2 - 1) + 1;

                double tmpAlpha = (2 * tmpHHOfChosenOne - tmpFi * (tmpHHOfChosenOne + 1) / (tmpHHOfChosenOne * (tmpHHOfChosenOne - 1)));
                double tmpBeta = (2 * (tmpFi - 1) / (tmpHHOfChosenOne * (tmpHHOfChosenOne - 1)));

                double tmpProbability = tmpAlpha + tmpBeta * MetaMain.CalculateRouteCost(parPopulation[i], parDictionaryNodes);

                tmpFitnesses.Add(tmpProbability);


            }

            for (int i = 0; i < parPopulation.Count; i++)
            {
                double tmpProb = MetaMain.CalculateRouteCost(parPopulation[i], parDictionaryNodes);
                tmpRouteCosts.Add(tmpProb);

            }

            double tmpSum = tmpRouteCosts.Sum();

            double tmpOldProb = 0.00;

            for (int i = 0; i < parPopulation.Count; i++)
            {
                double tmpCost = MetaMain.CalculateRouteCost(parPopulation[i], parDictionaryNodes);
                tmpProbabilities.Add(new []{ tmpOldProb, tmpOldProb +  (tmpCost / tmpSum) });
                tmpOldProb = tmpOldProb + (tmpCost / tmpSum);
            }



            /*  double tmpSum = tmpFitnesses.Sum();
            

            for (int i = 0; i < parPopulation.Count; i++)
            {
                double tmpProb = tmpFitnesses[i] / tmpSum; 
                tmpProbabilities.Add(tmpProb);
            }
            */



            double tmpRGenerated = aRandomUniformRGenerator.NextDouble() * (1.00 / parPopulation.Count - 0.0) + 0.0;


            double tmpSumProb = 0.00;
            for (int i = 0; i < tmpProbabilities.Count; i++)
            {
                tmpRGenerated += (i) / (double)tmpProbabilities.Count;

                for (int j = 0; j < tmpProbabilities.Count; j++)
                {
                    
                    if (tmpProbabilities[j][0] < tmpRGenerated && tmpProbabilities[j][1] > tmpRGenerated)
                    {
                        tmpChosenList.Add(i);
                        break;
                    }

                }

            }

            RouteComparer tmpComparer = new RouteComparer(parPopulation, parDictionaryNodes);

            tmpChosenList.Sort(tmpComparer);

            return new List<int>() { tmpChosenList[0], tmpChosenList[1]};
        }

        public List<int> SelectParents(List<List<int>> parPopulation)
        {
            int tmpFirstIndividual = aRandomFirst.Next(parPopulation.Count);
            int tmpSecondIndividual = -1;

            do
            {
                tmpSecondIndividual = aRandomSecond.Next(parPopulation.Count);
            } while (tmpFirstIndividual == tmpSecondIndividual);
            //

            return new List<int>() { tmpFirstIndividual, tmpSecondIndividual };
        }

        public class RouteComparer : IComparer<int>
        {
            private Dictionary<int, MetaNode> aDictionaryMetaNode;

            private List<List<int>> aPopulation;
            public RouteComparer(List<List<int>> parPopulation, Dictionary<int, MetaNode> parDictionaryNodes)
            {
                aDictionaryMetaNode = parDictionaryNodes;
                aPopulation = parPopulation;

            }

            public int Compare(int x, int y)
            {
                double tmpXCost = MetaMain.CalculateRouteCost(aPopulation[x], aDictionaryMetaNode);
                double tmpYCost = MetaMain.CalculateRouteCost(aPopulation[y], aDictionaryMetaNode);
                
                if (tmpXCost < tmpYCost)
                    return -1;
                else if (tmpXCost > tmpYCost)
                    return 1;
                return 0;
            }
        }
    }
}
