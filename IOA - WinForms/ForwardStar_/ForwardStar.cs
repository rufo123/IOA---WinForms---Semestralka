using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ShortestPathIOA.ForwardStar_
{
    public class ForwardStar
    {
        private Dictionary<int, int> aArrayPointers;

        private Dictionary<int, Vector2> aDictionaryCoordinates;

        /// <summary>
        /// Dictionary - Vrchol - Pozicia v poli
        /// </summary>
        private Dictionary<int, int> aDictionaryIndex;

        private List<ForwardStarItem> aForwardStarItemList;

        private int aIndexCounter;

        private int aCurrentNodeIndex;

        public int CountNodesConnected
        {
            get => aDictionaryCoordinates.Count;
        }

        public int CountNodesAll
        {
            get => aArrayPointers.Count;
        }

        public ForwardStar(int parCountOfNodes)
        {
            aArrayPointers = new Dictionary<int, int>(parCountOfNodes);
            aForwardStarItemList = new List<ForwardStarItem>();
            aDictionaryCoordinates = new Dictionary<int, Vector2>(parCountOfNodes);
            aDictionaryIndex = new Dictionary<int, int>(parCountOfNodes);

            aIndexCounter = 0;
            aCurrentNodeIndex = 0;
        }

        public void Add(int parNode, int parTargetNode, double parDistance)
        {
            aForwardStarItemList.Add(new ForwardStarItem(parTargetNode, parDistance, parNode));
        }

        public void AddCoordinate(int parNode, Vector2 parCoordinate)
        {
            aDictionaryCoordinates.TryAdd(parNode, parCoordinate);
        }

        public void Finalise()
        {
            aForwardStarItemList.Sort();

            int aIndexInList = 0;
            int aNodeId = -1;
            int aCounter = 0;

            for (int i = 0; i < aForwardStarItemList.Count; i++)
            {

                if (aForwardStarItemList[i].InitialNode != aNodeId)
                {
                    aNodeId = aForwardStarItemList[i].InitialNode;
                    aArrayPointers.Add(aNodeId, aIndexInList);
                    aDictionaryIndex.Add(aNodeId, aCounter);
                    aCounter++;
                }

                aIndexInList++;
            }
        }

        public ForwardStarItem Find(int parStartNode, int parEndNode)
        {

            int tmpPointer = -1;
            int tmpEndPointer = -1;


            if (!aArrayPointers.TryGetValue(parStartNode, out tmpPointer))
            {
                return null;
            }


            while (aForwardStarItemList.Count > tmpPointer && aForwardStarItemList[tmpPointer].EndNode != parEndNode && aForwardStarItemList[tmpPointer].InitialNode == parStartNode)
            {
                tmpPointer++;
            }

            if (aForwardStarItemList.Count <= tmpPointer || aForwardStarItemList[tmpPointer].InitialNode != parStartNode)
            {
                return null;
            }

            if (aForwardStarItemList[tmpPointer].EndNode == parEndNode)
            {
                return aForwardStarItemList[tmpPointer];
            }


            return null;
        }

        public List<ForwardStarItem> FindAllConnected(int parStartNode)
        {
            if (!aArrayPointers.TryGetValue(parStartNode, out int tmpPointer))
            {
                return null;
            }

            List<ForwardStarItem> tmpReturnList = new List<ForwardStarItem>();


            for (int i = tmpPointer; i < aForwardStarItemList.Count; i++)
            {
                if (aForwardStarItemList[i].InitialNode == parStartNode)
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

        public int GetIndexAtNode(int parNodeId)
        {
            aDictionaryIndex.TryGetValue(parNodeId, out int tmpReturnIndex);
            return tmpReturnIndex;
        }

        public List<int> GetListNodes()
        {
            return aArrayPointers.Keys.ToList();
        }

        public float GetEuclideanDistance(int parNode1, int parNode2)
        {
            return Vector2.Distance(aDictionaryCoordinates[parNode1], aDictionaryCoordinates[parNode2]);
        }

        public Vector2 GetCoordinate(int parNode)
        {
            return aDictionaryCoordinates[parNode];
        }

    }
}
