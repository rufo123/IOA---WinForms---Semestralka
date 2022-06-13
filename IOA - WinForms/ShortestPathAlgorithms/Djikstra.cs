using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;
using ShortestPathIOA.ForwardStar_;
using static ShortestPathIOA.Constants;


namespace ShortestPathIOA
{
    public class Djikstra
    {
        private int V;
        private double[] dist;
        private int[] prev;
        private bool[] visited;
        private int currentNode;
        private ForwardStar forwardStar;


        public Djikstra(ForwardStar parInputStar)
        {
            forwardStar = parInputStar;
        }

        public void DjikstraAllFromSource(ForwardStar parInputStar, int parInitialNode)
        {
            V = (int)Math.Sqrt(parInputStar.CountNodesAll);
            dist = new double[V];
            visited = new bool[V];
            Array.Fill(dist, Constants.INF);
            Array.Fill(visited, false);
            dist[parInitialNode] = 0;
            currentNode = parInitialNode;
           



            // Shortest Path
            for (int i = 0; i < V - 1; i++)
            {
                int u = MinDistance();

                visited[u] = true;

                for (int j = 0; j < V; j++)
                {

                    if (!visited[j])
                    {

                        ForwardStarItem tmpStarItem = forwardStar.Find(u, j);

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

            PrintResult();

        }

        public DistanceWPerformance DjikstaShortestPath(int parStartNode, int parEndNode)
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

            List<int> tmpListNodes = forwardStar.GetListNodes();


            dist[forwardStar.GetIndexAtNode(parStartNode)] = INF;
            prev[forwardStar.GetIndexAtNode(parStartNode)] = -1;
            
            dist[forwardStar.GetIndexAtNode(parStartNode)] = 0;
            tmpPriorityQueue.Enqueue(parStartNode, dist[forwardStar.GetIndexAtNode(parStartNode)]);

            while (tmpPriorityQueue.Count > 0)
            {
                u = tmpPriorityQueue.Dequeue();
                tmpCountOfPriorityDequeue++;

                if (u == parEndNode)
                {
                    return PrintOneResult(prev, dist, parStartNode, parEndNode, tmpCountOfPriorityDequeue);
                }

                List<ForwardStarItem> tmpNeighbors = forwardStar.FindAllConnected(u);

                foreach (var v in tmpNeighbors)
                {

                    if (v.EndNode == -1)
                    {
                        Console.Write("D");
                    }

                    
                    double alt = dist[forwardStar.GetIndexAtNode(u)] + v.Distance;

                    if (v.Distance != 0 && dist[forwardStar.GetIndexAtNode(u)] != INF && v.Distance != INF)
                    {
                        if (alt < dist[forwardStar.GetIndexAtNode(v.EndNode)])
                        {
                            dist[forwardStar.GetIndexAtNode(v.EndNode)] = alt;
                            prev[forwardStar.GetIndexAtNode(v.EndNode)] = u;
                            tmpPriorityQueue.EnqueueWithoutDuplicates(v.EndNode, alt);

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

        public void PrintResult()
        {
            for (int i = 0; i < V; i++)
            {
                Console.WriteLine("Vrchol " + i + " - " + dist[i]);
            }
        }

        public DistanceWPerformance PrintOneResult(int[] parPrev, double[] parDistance, int parStartNode, int parEndNode, int tmpCountOfDequeue)
        {
             string tmpFinalRoute = parEndNode + "";

            int tmpCurIndex = parEndNode;

            while (tmpCurIndex != parStartNode)
            {
                int tmpPrevIndex = tmpCurIndex;
                tmpCurIndex = parPrev[forwardStar.GetIndexAtNode(tmpCurIndex)];
               tmpFinalRoute = tmpCurIndex + " - " + tmpFinalRoute;
            }

            Console.WriteLine("Path:");
            Console.WriteLine(tmpFinalRoute);
            Console.WriteLine("Distance: " + parDistance[forwardStar.GetIndexAtNode(parEndNode)]);

            return new DistanceWPerformance(parDistance[forwardStar.GetIndexAtNode(parEndNode)], tmpCountOfDequeue);

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
