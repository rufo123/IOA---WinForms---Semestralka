using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using IOA___WinForms.SemestralkaPart1.ForwardStarSemestralka;
using IOA___WinForms.SemestralkaPart1.ForwardStarShortest;
using Priority_Queue;
using ShortestPathIOA;
using ShortestPathIOA.ForwardStar_;
using static ShortestPathIOA.Constants;


namespace IOA___WinForms.SemestralkaPart1
{
    public class DjikstraSem
    {
        private int V;
        private double[] dist;
        private int[] prev;
        private bool[] visited;
        private Node currentNode;
        private ForwardStarSem forwardStar;


        public DjikstraSem(ForwardStarSem parInputStar)
        {
            forwardStar = parInputStar;
        }

        public double[,] CalculateDistanceMatrix(ForwardStarShortestPath parForwardStartShortestPaths)
        {
            double[,] tmpNewDistanceMatrix = new double[forwardStar.GetCountNodes(), forwardStar.GetCountNodes()];

            Node[] tmpNodes = forwardStar.UniqueNodeDictionary.Values.ToArray();
            Array.Sort(tmpNodes);

            parForwardStartShortestPaths.Reset();

            for (int i = 0; i < tmpNodes.Length; i++)
            {
                DjikstraAllFromSource(tmpNodes[i], i, tmpNewDistanceMatrix, tmpNodes, parForwardStartShortestPaths);
            }

            for (int i = 0; i < tmpNewDistanceMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < tmpNewDistanceMatrix.GetLength(1); j++)
                {
                    Debug.Write(tmpNewDistanceMatrix[i, j] + "\t");
                }
                Debug.WriteLine("");
            }

            parForwardStartShortestPaths.Finalise();

            return tmpNewDistanceMatrix;
        }

        public void DjikstraAllFromSource(Node parInitialNode, int parIterationNumber, double[,] parDistanceMatrix, Node[] parNodes, ForwardStarShortestPath parForwardStartShortestPaths)
        {
            V = forwardStar.GetCountNodes();
            dist = new double[V];
            visited = new bool[V];
            Array.Fill(dist, Constants.INF);
            Array.Fill(visited, false);
            dist[forwardStar.GetIndexAtNode(parInitialNode)] = 0;
            currentNode = parInitialNode;


            Node[] tmpNodes = parNodes;
          

            // Shortest Path

            for (int i = 0; i < V - 1; i++)
            {
                int u = MinDistance();

                visited[u] = true;
                
                for (int j = 0; j < V; j++)
                {

                    if (!visited[j])
                    {

                        ForwardStarItemSem tmpStarItem = forwardStar.Find(tmpNodes[u], tmpNodes[j]);

                        if (tmpStarItem != null && tmpStarItem.Distance != 0 && dist[u] != INF )
                        {
                            if (dist[u] + tmpStarItem.Distance < dist[j])
                            {
                                dist[j] = dist[u] + tmpStarItem.Distance;
                            }
                        }
                    }


                }
            }

            PrintResult(tmpNodes, false, parIterationNumber, parDistanceMatrix, parInitialNode, parForwardStartShortestPaths);

        }

        public DistanceWPerformance DjikstaShortestPath(Node parStartNode, Node parEndNode)
        {

            V = forwardStar.CountNodesAll;
            dist = new double[V];
            prev = new int[V];
            visited = new bool[V];
            Array.Fill(dist, Constants.INF);
            Array.Fill(prev, -1);
            Array.Fill(visited, false);
            
            currentNode = parStartNode;

            int tmpDistance = 0;

            int tmpCountOfPriorityDequeue = 0;

            SimplePriorityQueue<int, double> tmpPriorityQueue = new SimplePriorityQueue<int, double>();

            int u;

            List<Node> tmpListNodes = forwardStar.GetListNodes();


            dist[forwardStar.GetIndexAtNode(parStartNode)] = INF;
            prev[forwardStar.GetIndexAtNode(parStartNode)] = -1;
            
            dist[forwardStar.GetIndexAtNode(parStartNode)] = 0;
            tmpPriorityQueue.Enqueue(parStartNode.Id, dist[forwardStar.GetIndexAtNode(parStartNode)]);

            while (tmpPriorityQueue.Count > 0)
            {
                u = tmpPriorityQueue.Dequeue();
                tmpCountOfPriorityDequeue++;

                if (u == parEndNode.Id)
                {
                    return PrintOneResult(prev, dist, parStartNode.Id, parEndNode.Id, tmpCountOfPriorityDequeue);
                }

                List<ForwardStarItemSem> tmpNeighbors = forwardStar.FindAllConnected(forwardStar.GetNodeById(u));

                foreach (var v in tmpNeighbors)
                {

                    if (v.EndNode.Id == -1)
                    {
                        Console.Write("D");
                    }

                    
                    double alt = dist[forwardStar.GetIndexAtNode(forwardStar.GetNodeById(u))] + v.Distance;

                    if (v.Distance != 0 && dist[forwardStar.GetIndexAtNode(forwardStar.GetNodeById(u))] != INF && v.Distance != INF)
                    {
                        if (alt < dist[forwardStar.GetIndexAtNode(v.EndNode)])
                        {
                            dist[forwardStar.GetIndexAtNode(v.EndNode)] = alt;
                            prev[forwardStar.GetIndexAtNode(v.EndNode)] = u;
                            tmpPriorityQueue.EnqueueWithoutDuplicates(v.EndNode.Id, alt);

                        }
                    }


                  
                }
            }


            

            return new DistanceWPerformance(-1, tmpCountOfPriorityDequeue);

        }

        public int MinDistance()
        {

            int tmpMinValue = int.MaxValue;
            int tmpMinIndex = -1;

            for (int i = 0; i < V; i++)
            {
                if (!visited[i] && dist[i] <= tmpMinValue)
                {
                    tmpMinValue = (int)dist[i];
                    tmpMinIndex = i;
                }
            }

            return tmpMinIndex;
        }

        public void PrintResult(Node[] tmpNodes, bool tmpPrintDebug, int parTmpIteration, double[,] parDistanceMatrix, Node parInitialNode, ForwardStarShortestPath parForwardStartShortestPaths)
        {

            if (tmpPrintDebug)
            {
                for (int i = 0; i < V; i++)
                {
                    Debug.WriteLine("Vrchol " + parInitialNode.Id + " - " + tmpNodes[i].Id + " - " + dist[i]);
                }

                return;
            }

            for (int i = 0; i < V; i++)
            {
                parForwardStartShortestPaths.Add(parInitialNode, tmpNodes[i], dist[i]);
                parDistanceMatrix[parTmpIteration, i] = dist[i];
            }

        }

        public DistanceWPerformance PrintOneResult(int[] parPrev, double[] parDistance, int parStartNode, int parEndNode, int tmpCountOfDequeue)
        {
             string tmpFinalRoute = parEndNode + "";

            int tmpCurIndex = parEndNode;

            while (tmpCurIndex != parStartNode)
            {
                int tmpPrevIndex = tmpCurIndex;
                tmpCurIndex = parPrev[forwardStar.GetIndexAtNode(forwardStar.GetNodeById(tmpCurIndex))];
               tmpFinalRoute = tmpCurIndex + " - " + tmpFinalRoute;
            }

            Debug.WriteLine("Path:");
            Debug.WriteLine(tmpFinalRoute);
            Debug.WriteLine("Distance: " + parDistance[forwardStar.GetIndexAtNode(forwardStar.GetNodeById(parEndNode))]);

            return new DistanceWPerformance(parDistance[forwardStar.GetIndexAtNode(forwardStar.GetNodeById(parEndNode))], tmpCountOfDequeue);

        }

        public List<int> Neighbors(int parCurrentNode, int[,] parInputMatrix)
        {

            List<int> tmpReturnList = new List<int>(V);

            for (int i = 0; i < parInputMatrix.GetLength(0); i++)
            {
                if (parInputMatrix[parCurrentNode, i] != INF && parInputMatrix[parCurrentNode, i] != 0)
                {
                    tmpReturnList.Add(i);
                }
            }

            return tmpReturnList;
        }
    }
}
