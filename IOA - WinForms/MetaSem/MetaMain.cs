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

        private static int aStartNode = 5;

        public MetaMain()
        {
            LoaderNetwork tmpNetwork = new LoaderNetwork();

            aNodes = tmpNetwork.Load(out aSize);

            aInitSolution = new List<int>(aSize);

            aInitSolution = Enumerable.Range(1, aSize).ToList();

            GeneticAlgorithm tmpGeneticAlgorithm = new GeneticAlgorithm(aInitSolution, aNodes, 100);

        }
        
        public static int CalculateRouteCost(List<int> parSolution, Dictionary<int, MetaNode> parNodesDictionary)
        {

            int tmpCost = 0;

            int tmpOldNodeID = aStartNode;

            foreach (int tmpNodeID in parSolution)
            {
                tmpCost += Math.Abs(parNodesDictionary[tmpNodeID].Position - parNodesDictionary[tmpOldNodeID].Position);
                tmpOldNodeID = tmpNodeID;
            }

            tmpCost += Math.Abs(parNodesDictionary[parSolution.Count - 1].Position - parNodesDictionary[aStartNode].Position);

            return tmpCost;
        }
        
        public static void ContinuityChecker(List<int> parPop)
        {
            if (parPop.Sum() != 106030 - aStartNode)
            {
                throw new DataMisalignedException("Population is missing some members!");
            }

        }
    }
}
