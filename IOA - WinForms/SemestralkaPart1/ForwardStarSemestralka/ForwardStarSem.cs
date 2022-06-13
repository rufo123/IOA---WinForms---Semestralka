﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace IOA___WinForms.SemestralkaPart1.ForwardStarSemestralka
{
    public class ForwardStarSem
    {
        private Dictionary<Node, int> aArrayPointers;

        private Dictionary<int, Vector2> aDictionaryCoordinates;

        /// <summary>
        /// Dictionary - Vrchol - Pozicia v poli
        /// </summary>
        private Dictionary<Node, int> aDictionaryIndex;

        private Dictionary<Node, int> aDictionaryUnconnected;

        private List<ForwardStarItemSem> aForwardStarItemList;

        private Dictionary<int, Node> aUniqueNodeDictionary;

        private Dictionary<int, Node> aRemovedNodesDictionary;

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

        public Dictionary<int, Node> UniqueNodeDictionary
        {
            get => aUniqueNodeDictionary;
        }

        public ForwardStarSem(int parCountOfNodes)
        {
            aArrayPointers = new Dictionary<Node, int>(parCountOfNodes);
            aForwardStarItemList = new List<ForwardStarItemSem>();
            aDictionaryCoordinates = new Dictionary<int, Vector2>(parCountOfNodes);
            aDictionaryIndex = new Dictionary<Node, int>(parCountOfNodes);
            aDictionaryUnconnected = new Dictionary<Node, int>();
            aUniqueNodeDictionary = new Dictionary<int, Node>(parCountOfNodes);
            aRemovedNodesDictionary = new Dictionary<int, Node>(parCountOfNodes);

            aIndexCounter = 0;
            aCurrentNodeIndex = 0;
        }

        public void Add(Node parNode, Node parTargetNode, double parDistance)
        {

            aUniqueNodeDictionary.TryAdd(parNode.Id, parNode);
            aUniqueNodeDictionary.TryAdd(parTargetNode.Id, parTargetNode);
            aForwardStarItemList.Add(new ForwardStarItemSem(aUniqueNodeDictionary[parTargetNode.Id], parDistance, aUniqueNodeDictionary[parNode.Id]));
        }

        public void AddAloneNode(Node parNode)
        {

            aUniqueNodeDictionary.TryAdd(parNode.Id, parNode);
            aForwardStarItemList.Add(new ForwardStarItemSem(null, -1, aUniqueNodeDictionary[parNode.Id]));

        }

        public void AddCoordinate(int parNode, Vector2 parCoordinate)
        {
            aDictionaryCoordinates.TryAdd(parNode, parCoordinate);
        }

        public void Finalise(Node tmpDeletedNode = null)
        {



            Dictionary<int, int> test = new Dictionary<int, int>();

            aArrayPointers.Clear();
            aDictionaryIndex.Clear();
            aForwardStarItemList.Sort();

            int aIndexInList = 0;
            Node aNode = new Node();
            int aCounter = 0;




            for (int i = 0; i < aForwardStarItemList.Count; i++)
            {
                bool tmpRemoved = false;

                if (tmpDeletedNode != null)
                {
                    int tmpCounter = 0;

                    if (aForwardStarItemList[i].InitialNode.Id == 9)
                    {
                        Console.WriteLine();
                    }

                    if (aForwardStarItemList[i].EndNode != null && aForwardStarItemList[i].EndNode.Id != tmpDeletedNode.Id) {
                       
                        if (test.TryGetValue(aForwardStarItemList[i].InitialNode.Id, out tmpCounter))
                        {
                            tmpCounter++;
                            test[aForwardStarItemList[i].InitialNode.Id] = tmpCounter;
                        }
                        else
                        {
                            test.Add(aForwardStarItemList[i].InitialNode.Id, 1);
                        }
                    }
                    else if (aForwardStarItemList[i].EndNode != null)
                    {
                        if (!test.ContainsKey(aForwardStarItemList[i].InitialNode.Id))
                        {
                            test.Add(aForwardStarItemList[i].InitialNode.Id, 0);
                        }
                    }

                }

           
            }

            for (int i = 0; i < aForwardStarItemList.Count; i++)
            {

                bool tmpRemoved = false;

                while (!aRemovedNodesDictionary.ContainsKey(aForwardStarItemList[i].InitialNode.Id) &&
                       aForwardStarItemList[i].EndNode != null &&
                       aRemovedNodesDictionary.ContainsKey(aForwardStarItemList[i].EndNode.Id))
                {
                    

                    int tmpConnectedTo = -1;

                    test.TryGetValue(aForwardStarItemList[i].InitialNode.Id, out tmpConnectedTo);
                    if (tmpConnectedTo == 0)
                    {
                        aForwardStarItemList[i].EndNode = null;
                        tmpRemoved = false;
                    }
                    else
                    {
                        aForwardStarItemList.RemoveAt(i);
                        tmpRemoved = true;
                    }

                }


                while (aRemovedNodesDictionary.ContainsKey(aForwardStarItemList[i].InitialNode.Id) && (aForwardStarItemList[i].EndNode != null && !aRemovedNodesDictionary.ContainsKey(aForwardStarItemList[i].EndNode.Id)))
                {
                    aForwardStarItemList.RemoveAt(i);
                    tmpRemoved = true;

                } 




                if (aForwardStarItemList[i].InitialNode.CompareTo(aNode) != 0)
                {
                    aNode = aForwardStarItemList[i].InitialNode;

                    /*                    if (!aRemovedNodesDictionary.ContainsKey(aNode.Id) && aRemovedNodesDictionary.ContainsKey(aForwardStarItemList[aIndexInList].EndNode.Id))
                                        {
                                            aForwardStarItemList[i].EndNode = null;

                                            aArrayPointers.Add(aNode, aIndexInList);
                                            aDictionaryIndex.Add(aNode, aCounter);
                                            aCounter++;
                                        }

                                        else if (aRemovedNodesDictionary.ContainsKey(aNode.Id) && !aRemovedNodesDictionary.ContainsKey(aForwardStarItemList[aIndexInList].EndNode.Id))
                                        {
                                            aForwardStarItemList.RemoveAt(i);
                                            aCounter++;

                                        }
                                        else
                                        {
                                            aArrayPointers.Add(aNode, aIndexInList);
                                            aDictionaryIndex.Add(aNode, aCounter);
                                            aCounter++;
                                        }
                    */

                    if (aNode.Id == 7)
                    {
                        Console.WriteLine();
                    }

                    aArrayPointers.Add(aNode, aIndexInList);
                    aDictionaryIndex.Add(aNode, aCounter);
                    aCounter++;



                }

                aIndexInList++;
            }
        }

        public ForwardStarItemSem Find(Node parStartNode, Node parEndNode)
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

        public List<ForwardStarItemSem> FindAllConnected(Node parStartNode)
        {
            if (!aArrayPointers.TryGetValue(parStartNode, out int tmpPointer))
            {
                return null;
            }

            List<ForwardStarItemSem> tmpReturnList = new List<ForwardStarItemSem>();


            for (int i = tmpPointer; i < aForwardStarItemList.Count; i++)
            {
                if (aForwardStarItemList[i].InitialNode.CompareTo(parStartNode) == 0 && aForwardStarItemList[i].EndNode != null)
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

        public int GetIndexAtNode(Node parNodeId)
        {
            aDictionaryIndex.TryGetValue(parNodeId, out int tmpReturnIndex);
            return tmpReturnIndex;
        }

        public List<Node> GetListNodes()
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

        public void UpdateNodeCoords(Node parNode, Vector2 parCoordinates)
        {
            List<ForwardStarItemSem> tmpList = FindAllConnected(parNode);

            foreach (var tmpNode in tmpList)
            {

            }

        }

        public void UpdateNodeCapacity(Node parNode, int parCapacity)
        {

        }

        public void DeleteEdge(Edge parEdge)
        {
            var test = Find(parEdge.FirstNode, parEdge.SecondNode);
            var test2 = Find(parEdge.SecondNode, parEdge.FirstNode);

            for (int i = 0; i < aForwardStarItemList.Count; i++)
            {
                if (aForwardStarItemList[i] == test || aForwardStarItemList[i] == test2)
                {
                    aForwardStarItemList.Remove(aForwardStarItemList[i]);
                }
            }

            Finalise();
        }

        public void DeleteNode(Node parNode)
        {
            if (aUniqueNodeDictionary.ContainsKey(parNode.Id))
            {
                aRemovedNodesDictionary.TryAdd(parNode.Id, parNode);
                aUniqueNodeDictionary.Remove(parNode.Id);
            }

            this.Finalise(parNode);
        }

        public int GetLastIdUsed()
        {
            return (aUniqueNodeDictionary.Keys.Max());
        }

        public void AddEdge(Edge parEdge)
        {


            if (Find(parEdge.FirstNode, parEdge.SecondNode) != null &&
                Find(parEdge.SecondNode, parEdge.FirstNode) != null)
            {
                // Edge Exists
            }

            aForwardStarItemList.Add(new ForwardStarItemSem(parEdge.FirstNode, GetEuclideanDistance(parEdge.FirstNode.Id, parEdge.SecondNode.Id), parEdge.SecondNode));
            aForwardStarItemList.Add(new ForwardStarItemSem(parEdge.SecondNode, GetEuclideanDistance(parEdge.FirstNode.Id, parEdge.SecondNode.Id), parEdge.FirstNode));

            Finalise();
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