using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;
using ShortestPathIOA.ForwardStar_;
using static ShortestPathIOA.Constants;

namespace ShortestPathIOA
{
    public class GreedyBestFirstSearch
    {

        private int V;
        private SimplePriorityQueue<int> openPriorityQeueue;
        private bool[] visited;
        private int[] prev;
        private bool aMinimalisticOutput;
        private ForwardStar aForwardStar;
        

        public GreedyBestFirstSearch(ForwardStar parStar, bool parMinimalisticOutput = false)
        {

            aMinimalisticOutput = parMinimalisticOutput;
            aForwardStar = parStar;
            V = aForwardStar.CountNodesAll;
            visited = new bool[V];
            prev = new int[V];
            openPriorityQeueue = new SimplePriorityQueue<int>();
            

        }

        public DistanceWPerformance GreedyBFS(int parInitialNode, int parTargetNode, ForwardStar parStar)
        {
           
            openPriorityQeueue.Clear();
            Array.Fill(visited, false);
            Array.Fill(prev, -1);
            int tmpCountOfDequeue = 0;

            visited[parStar.GetIndexAtNode(parInitialNode)] = true;

            double tmpCurrentNodeDistance = INF;

            double tmpDistance = 0;


            int tmpCurrentNode = parInitialNode;


  

            if (tmpCurrentNode == parTargetNode)
            {
            
                if (parInitialNode == tmpCurrentNode)
                {
                    tmpDistance += 0;
                }
                else
                {
                    tmpDistance += parStar.Find(tmpCurrentNode, parTargetNode).Distance;
                }


                //  PrintShortestPath(tmpShortestPath, tmpDistance);

                return new DistanceWPerformance(tmpDistance, tmpCountOfDequeue);

            }

            // Najprv pridame zaciatocny vrchol do open Listu
            openPriorityQeueue.Enqueue(parInitialNode, HeuristicCostFunction(parInitialNode, parTargetNode, parStar));

            int tmpPreviousNode = parInitialNode;

            while (openPriorityQeueue.Count > 0)
            {

               

                tmpCurrentNode = openPriorityQeueue.Dequeue();
                tmpCountOfDequeue++;

               // tmpShortestPath.Add(tmpCurrentNode);

                if (tmpPreviousNode == tmpCurrentNode)
                {
                    tmpDistance += 0;
                }


                List<ForwardStarItem> tmpNeighbors = parStar.FindAllConnected(tmpCurrentNode);

                foreach (var n in tmpNeighbors)
                {
                    if (visited[parStar.GetIndexAtNode(n.EndNode)] == false)
                    {

                        if (n.EndNode == parTargetNode)
                        {
                           // tmpShortestPath.Add(n.EndNode);

                            if (tmpCurrentNode == 1 && n.EndNode == 2)
                            {
                                Console.WriteLine();
                            }

                            prev[parStar.GetIndexAtNode(n.EndNode)] = tmpCurrentNode;
                            tmpDistance += parStar.Find(tmpCurrentNode, n.EndNode).Distance;
                            //  PrintShortestPath(tmpShortestPath, tmpDistance);
                            
                            return new DistanceWPerformance(CalculateCompletePath(prev, parInitialNode, parTargetNode, parStar), tmpCountOfDequeue);
                        }
                        else
                        {
                            visited[parStar.GetIndexAtNode(n.EndNode)] = true;
                            prev[parStar.GetIndexAtNode(n.EndNode)] = tmpCurrentNode;
                            openPriorityQeueue.Enqueue(n.EndNode, HeuristicCostFunction(n.EndNode, parTargetNode, parStar));
                        }
                    }
                }
                


                tmpPreviousNode = tmpCurrentNode;
            }

            throw new ArgumentOutOfRangeException(@"Chyba");

        }

        public float HeuristicCostFunction(int tmpStartNode, int tmpEndNode, ForwardStar parStar)
        {
           return parStar.GetEuclideanDistance(tmpStartNode, tmpEndNode);
        }

        public float CalculateCompletePath(int[] parPrev, int parStartNode, int parEndNode, ForwardStar parStar)
        {
            List<int> tmpShortestPath = new List<int>();

            int tmpCurrentNode = parEndNode;

            float tmpReturnDistance = 0;

            Console.WriteLine("Path: ");

            string tmpReturnString = string.Empty; 

            while (tmpCurrentNode != parStartNode)
            {
                tmpReturnString = " - " + tmpCurrentNode + tmpReturnString;
               
                int tmpNewNode = parPrev[parStar.GetIndexAtNode(tmpCurrentNode)];
                if (tmpCurrentNode == tmpNewNode)
                {
                    tmpReturnDistance += 0;
                }
                else
                {
                    tmpReturnDistance += (float)parStar.Find(tmpNewNode, tmpCurrentNode).Distance;
                }
                tmpCurrentNode = tmpNewNode;
            }

            tmpReturnString = parStartNode + tmpReturnString;

            Console.WriteLine(tmpReturnString);
            Console.WriteLine(tmpReturnDistance);

            return tmpReturnDistance;
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

        public void PrintShortestPath(List<int> parPathList, double parDistance)
        {
            if (!aMinimalisticOutput)
            {
                Console.WriteLine("Path: ");
                for (int i = 0; i < parPathList.Count; i++)
                {
                    if (i != parPathList.Count - 1)
                    {
                        Console.Write(parPathList[i] + " - ");
                    }
                    else
                    {
                        Console.WriteLine(parPathList[i]);
                    }
                }
                Console.WriteLine("Distance: " + parDistance);
            }
            else
            {
                Console.WriteLine("Vrchol: " + parPathList[parPathList.Count - 1] + " - " + parDistance);
            }

        }
    }
}
