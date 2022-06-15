using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOA___WinForms.MetaSem
{
    class MetaMain
    {

        private Dictionary<int, MetaNode> aNodes;

        private int aSize;

        private List<int> aInitSolution;

        public MetaMain()
        {
            LoaderNetwork tmpNetwork = new LoaderNetwork();

            aNodes = tmpNetwork.Load(out aSize);

            aInitSolution = new List<int>(aSize);

            aInitSolution = Enumerable.Range(1, aSize).ToList();

            GeneticAlgorithm tmpGeneticAlgorithm = new GeneticAlgorithm(aInitSolution, aNodes);

        }

        public static int CalculateRouteCost(List<int> parSolution, Dictionary<int, MetaNode> parNodesDictionary)
        {

            int tmpCost = 0;

            int tmpOldNodeID = 1;

            foreach (int tmpNodeID in parSolution)
            {
                tmpCost += Math.Abs(parNodesDictionary[tmpNodeID].Position - parNodesDictionary[tmpOldNodeID].Position);
                tmpOldNodeID = tmpNodeID;
            }
            
            return tmpCost;
        }

        public static void ContinuityChecker(List<int> parPop)
        {
            if (parPop.Sum() != 106030)
            {
                throw new DataMisalignedException("Population is missing some members!");
            }

        }
    }
}
