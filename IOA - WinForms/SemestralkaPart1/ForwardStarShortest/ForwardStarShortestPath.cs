using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace IOA___WinForms.SemestralkaPart1.ForwardStarShortest
{
    public class ForwardStarShortestPath
    {
        private List<ForwardStartItemShortest> aForwardStarItemList;

        private Dictionary<int, Node> aUniqueNodeDictionary;

        private Dictionary<Node, int> aArrayPointers;

        private bool aInterConnected;

        /// <summary>
        /// Dictionary - Vrchol - Pozicia v poli
        /// </summary>
        private Dictionary<Node, int> aDictionaryIndex;

        public ForwardStarShortestPath()
        {
            aForwardStarItemList = new List<ForwardStartItemShortest>();
            aUniqueNodeDictionary = new Dictionary<int, Node>();
            aUniqueNodeDictionary = new Dictionary<int, Node>();
            aArrayPointers = new Dictionary<Node, int>();
            aDictionaryIndex = new Dictionary<Node, int>();
            aInterConnected = true;
        }

        public void Reset()
        {
            aForwardStarItemList = new List<ForwardStartItemShortest>();
            aUniqueNodeDictionary = new Dictionary<int, Node>();
            aArrayPointers = new Dictionary<Node, int>();
            aDictionaryIndex = new Dictionary<Node, int>();
            aInterConnected = true;
        }

        public List<Node> ConvertRouteIndexesToNodes(List<int> parRouteIndexes)
        {

            List<Node> tmpNodes = GetListNodes();
            List<Node> tmpReturnRoute = new List<Node>(parRouteIndexes.Count);

            for (int i = 0; i < parRouteIndexes.Count; i++)
            {
                tmpReturnRoute.Add(tmpNodes[parRouteIndexes[i]]); 
            }

            return tmpReturnRoute;
        }

        public void Add(Node parNode, Node parTargetNode, double parShortestPathCost, List<int> parShortestPathRoute)
        {
            aUniqueNodeDictionary.TryAdd(parNode.Id, parNode);
            aUniqueNodeDictionary.TryAdd(parTargetNode.Id, parTargetNode);


            aForwardStarItemList.Add(new ForwardStartItemShortest(aUniqueNodeDictionary[parTargetNode.Id], aUniqueNodeDictionary[parNode.Id], parShortestPathCost, parShortestPathRoute));

            if (parShortestPathCost == ShortestPathIOA.Constants.INF)
            {
                aInterConnected = false;
            }
        }

        public void Finalise()
        {

            aArrayPointers.Clear();
            aDictionaryIndex.Clear();
            aForwardStarItemList.Sort();

            int aIndexInList = 0;
            Node aNode = new Node();
            int aCounter = 0;

            for (int i = 0; i < aForwardStarItemList.Count; i++)
            {

                if (aForwardStarItemList[i].StartingNode.CompareTo(aNode) != 0)
                {
                    aNode = aForwardStarItemList[i].StartingNode;

                    aArrayPointers.Add(aNode, aIndexInList);
                    aDictionaryIndex.Add(aNode, aCounter);
                    aCounter++;

                }

                aIndexInList++;
            }
        }

        public ForwardStartItemShortest Find(Node parStartNode, Node parEndNode)
        {


            int tmpPointer = -1;
            int tmpEndPointer = -1;


            if (!aArrayPointers.TryGetValue(parStartNode, out tmpPointer))
            {
                return null;
            }


            while (aForwardStarItemList.Count > tmpPointer && aForwardStarItemList[tmpPointer].EndingNode.Id != parEndNode.Id && aForwardStarItemList[tmpPointer].StartingNode.Id == parStartNode.Id)
            {
                tmpPointer++;
            }

            if (aForwardStarItemList.Count <= tmpPointer || aForwardStarItemList[tmpPointer].StartingNode.Id != parStartNode.Id)
            {
                return null;
            }

            if (aForwardStarItemList[tmpPointer].EndingNode.Id == parEndNode.Id)
            {
                return aForwardStarItemList[tmpPointer];
            }


            return null;
        }


        public List<ForwardStartItemShortest> FindAllConnected(Node parStartNode)
        {
            if (!aArrayPointers.TryGetValue(parStartNode, out int tmpPointer))
            {
                return null;
            }

            List<ForwardStartItemShortest> tmpReturnList = new List<ForwardStartItemShortest>();


            for (int i = tmpPointer; i < aForwardStarItemList.Count; i++)
            {
                if (aForwardStarItemList[i].StartingNode.CompareTo(parStartNode) == 0 && aForwardStarItemList[i].EndingNode != null)
                {
                    tmpReturnList.Add(aForwardStarItemList[i]);
                }
                else
                {
                    break;
                }
            }

            return tmpReturnList;
        }

        public bool IsNetworkInterConnected()
        {
            return aInterConnected;
        }

        public List<Node> GetListNodes()
        {
            return aArrayPointers.Keys.ToList();
        }

        public int GetCountNodes()
        {
            return aDictionaryIndex.Count;
        }

        public Node GetNodeById(int parId)
        {
            return aUniqueNodeDictionary[parId];
        }


    }
}
