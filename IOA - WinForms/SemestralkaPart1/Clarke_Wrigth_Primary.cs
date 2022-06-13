using System;
using System.Collections.Generic;
using System.Text;
using IOA___WinForms.SemestralkaPart1.ForwardStarShortest;

namespace IOA___WinForms.SemestralkaPart1
{
    public class Clarke_Wrigth_Primary
    {

        private ForwardStarShortestPath aForwardStarShortestPath;

        private double[,] aMatrix;

        private List<CoefficientAndNodes> aCoeffAndNodesList;

        private Dictionary<Node, List<CoefficientAndNodes>> aDictionaryOfAllowedCoeficients;

        private List<Routes> aRoutesList;

        private Dictionary<Node, Routes> aDictionaryRoutePointers;

        public Clarke_Wrigth_Primary(ForwardStarShortestPath parForwardStar)
        {
            aForwardStarShortestPath = parForwardStar;

            aCoeffAndNodesList = new List<CoefficientAndNodes>();

            aDictionaryOfAllowedCoeficients = new Dictionary<Node, List<CoefficientAndNodes>>();

            aRoutesList = new List<Routes>();

            aDictionaryRoutePointers = new Dictionary<Node, Routes>();

        }

        public void CalculateCoefficients()
        {
            Node tmpStredisko = aForwardStarShortestPath.GetNodeById(1);



            int indexI = 0;
            int indexJ = 0;

            var test = aForwardStarShortestPath.FindAllConnected(aForwardStarShortestPath.GetNodeById(3));

            List<Node> tmpListWithoutPrimarySource = aForwardStarShortestPath.GetListNodes();
            tmpListWithoutPrimarySource.Remove(tmpStredisko);

            aMatrix = new double[tmpListWithoutPrimarySource.Count, tmpListWithoutPrimarySource.Count];

            foreach (var i in tmpListWithoutPrimarySource)
            {

                foreach (var j in tmpListWithoutPrimarySource)
                {

                    if (indexJ - indexI > 0)
                    {
                        double tmpDIS = aForwardStarShortestPath.Find(i, tmpStredisko).ShortestPathCost;
                        double tmpDJS = aForwardStarShortestPath.Find(j, tmpStredisko).ShortestPathCost;

                        double tmpDIJ = 0;
                        if (j.Id == i.Id)
                        {
                            tmpDIJ = 0.00;
                        }
                        else
                        {
                            tmpDIJ = aForwardStarShortestPath.Find(i, j).ShortestPathCost;
                        }



                        aMatrix[indexI, indexJ] = tmpDIS + tmpDJS - tmpDIJ;

                        if (aMatrix[indexI, indexJ] > 0)
                        {

                            CoefficientAndNodes tmpCoefficientAndNodes = new CoefficientAndNodes(aMatrix[indexI, indexJ], i, j);

                            aCoeffAndNodesList.Add(tmpCoefficientAndNodes);

                            if (aDictionaryOfAllowedCoeficients.ContainsKey(i))
                            {
                                aDictionaryOfAllowedCoeficients[i].Add(tmpCoefficientAndNodes);

                            }
                            else
                            {
                                aDictionaryOfAllowedCoeficients.Add(i, new List<CoefficientAndNodes>() { tmpCoefficientAndNodes });
                            }

                            if (aDictionaryOfAllowedCoeficients.ContainsKey(j))
                            {
                                aDictionaryOfAllowedCoeficients[j].Add(tmpCoefficientAndNodes);

                            }
                            else
                            {
                                aDictionaryOfAllowedCoeficients.Add(j, new List<CoefficientAndNodes>() { tmpCoefficientAndNodes });
                            }

                        }
                    }



                    indexJ++;
                }

                indexI++;
                indexJ = 0;
            }

          List<Routes> tmpCalculatedRoutes = CalculateRoutes(tmpListWithoutPrimarySource);
        }


        public List<Routes> CalculateRoutes(List<Node> parListNodesWithoutPrimarySource)
        {

            int tmpK = 150;

            aCoeffAndNodesList.Sort();

            for (int i = 0; i < aCoeffAndNodesList.Count; i++)
            {
                if (aCoeffAndNodesList[i].Forbidden)
                {
                    continue;
                }

                double tmpCap1 = aCoeffAndNodesList[i].StartingNode.Capacity;
                double tmpCap2 = aCoeffAndNodesList[i].EndingNode.Capacity;

                if (aRoutesList.Count <= 0 && tmpK >= tmpCap1 + tmpCap2)
                {
                    aRoutesList.Add(new Routes(aCoeffAndNodesList[i].StartingNode, aCoeffAndNodesList[i].EndingNode,
                        new List<Node>() { aCoeffAndNodesList[i].StartingNode, aCoeffAndNodesList[i].EndingNode }, tmpCap1 + tmpCap2));

                    aDictionaryRoutePointers.Add(aCoeffAndNodesList[i].StartingNode, aRoutesList[0]);
                    aDictionaryRoutePointers.Add(aCoeffAndNodesList[i].EndingNode, aRoutesList[0]);

                    aCoeffAndNodesList[i].Forbidden = true;
                    //aCoeffAndNodesList.RemoveAt(i);

                    if (tmpK == tmpCap1 + tmpCap2)
                    {
                        RemoveFromDictionaryAndLists(aCoeffAndNodesList[i].StartingNode);
                        RemoveFromDictionaryAndLists(aCoeffAndNodesList[i].EndingNode);
                    }
                }

                else if (tmpK < tmpCap1 + tmpCap2)
                {
                    //
                    aCoeffAndNodesList.RemoveAt(i);
                    aCoeffAndNodesList[i].Forbidden = true;
                }
                else
                {

                    bool tmpRouteFound = false;

                    for (int j = 0; j < aRoutesList.Count; j++)
                    {
                        if (aRoutesList[j].NodeAtStart.Id == aCoeffAndNodesList[i].StartingNode.Id &&
                            aRoutesList[j].NodeAtEnd.Id == aCoeffAndNodesList[i].EndingNode.Id)
                        {
                            Console.WriteLine("Pepega");
                        }
                        else if (aRoutesList[j].NodeAtEnd.Id == aCoeffAndNodesList[i].EndingNode.Id &&
                          aRoutesList[j].NodeAtStart.Id == aCoeffAndNodesList[i].StartingNode.Id)
                        {
                            Console.WriteLine("Pepega");
                        }

                        if (aDictionaryRoutePointers.ContainsKey(aCoeffAndNodesList[i].StartingNode) &&
                            aDictionaryRoutePointers.ContainsKey(aCoeffAndNodesList[i].EndingNode))
                        {

                            Routes tmpRoute1 = aDictionaryRoutePointers[aCoeffAndNodesList[i].StartingNode];
                            Routes tmpRoute2 = aDictionaryRoutePointers[aCoeffAndNodesList[i].EndingNode];

                            if (tmpRoute1 == tmpRoute2)
                            {
                                aCoeffAndNodesList[j].Forbidden = true;
                                tmpRouteFound = true;
                            }

                            else if (tmpRoute1.Capacity + tmpRoute2.Capacity <= tmpK)
                            {
                                // Can Be Connected

                                if (tmpRoute1.NodeAtStart.Id == aCoeffAndNodesList[i].StartingNode.Id)
                                {
                                    if (tmpRoute2.NodeAtStart.Id == aCoeffAndNodesList[i].EndingNode.Id)
                                    {
                                        // Rotate And Add To Left
                                        aDictionaryRoutePointers[tmpRoute1.NodeAtStart] = tmpRoute2;
                                        aDictionaryRoutePointers[tmpRoute1.NodeAtEnd] = tmpRoute2;

                                        tmpRoute1.Route.Reverse();

                                        tmpRoute2.NodeAtStart = tmpRoute1.NodeAtEnd;
                                        tmpRoute2.Capacity += tmpRoute1.Capacity;
                                        tmpRoute2.Route.InsertRange(0, tmpRoute1.Route);
                                        aRoutesList.RemoveAt(aRoutesList.IndexOf(tmpRoute1));

                                        aCoeffAndNodesList[j].Forbidden = true;

                                        RemoveFromDictionaryAndLists(aCoeffAndNodesList[i].StartingNode);
                                        RemoveFromDictionaryAndLists(aCoeffAndNodesList[i].EndingNode);

                                        tmpRouteFound = true;

                                    }
                                    else if (tmpRoute2.NodeAtEnd.Id == aCoeffAndNodesList[i].EndingNode.Id)
                                    {
                                        // Add To Left

                                        aDictionaryRoutePointers[tmpRoute1.NodeAtStart] = tmpRoute2;
                                        aDictionaryRoutePointers[tmpRoute1.NodeAtEnd] = tmpRoute2;

                                        tmpRoute2.NodeAtEnd = tmpRoute1.NodeAtEnd;
                                        tmpRoute2.Capacity += tmpRoute1.Capacity;
                                        tmpRoute2.Route.AddRange(tmpRoute1.Route);
                                        aRoutesList.RemoveAt(aRoutesList.IndexOf(tmpRoute1));

                                        aCoeffAndNodesList[j].Forbidden = true;

                                        RemoveFromDictionaryAndLists(aCoeffAndNodesList[i].StartingNode);
                                        RemoveFromDictionaryAndLists(aCoeffAndNodesList[i].EndingNode);

                                        tmpRouteFound = true;

                                    }
                                }
                                else if (tmpRoute1.NodeAtEnd.Id == aCoeffAndNodesList[i].StartingNode.Id)
                                {
                                    if (tmpRoute2.NodeAtStart.Id == aCoeffAndNodesList[i].EndingNode.Id)
                                    {
                                        // Add To Right

                                        aDictionaryRoutePointers[tmpRoute2.NodeAtStart] = tmpRoute1;
                                        aDictionaryRoutePointers[tmpRoute2.NodeAtEnd] = tmpRoute1;

                                        tmpRoute1.NodeAtEnd = tmpRoute2.NodeAtEnd;
                                        tmpRoute1.Capacity += tmpRoute2.Capacity;
                                        tmpRoute1.Route.AddRange(tmpRoute2.Route);
                                        aRoutesList.RemoveAt(aRoutesList.IndexOf(tmpRoute2));

                                        aCoeffAndNodesList[j].Forbidden = true;

                                        RemoveFromDictionaryAndLists(aCoeffAndNodesList[i].StartingNode);
                                        RemoveFromDictionaryAndLists(aCoeffAndNodesList[i].EndingNode);

                                        tmpRouteFound = true;

                                    }
                                    else if (tmpRoute2.NodeAtEnd.Id == aCoeffAndNodesList[i].EndingNode.Id)
                                    {
                                        // Rotate And Add To Right

                                        aDictionaryRoutePointers[tmpRoute2.NodeAtStart] = tmpRoute1;
                                        aDictionaryRoutePointers[tmpRoute2.NodeAtEnd] = tmpRoute1;

                                        tmpRoute2.Route.Reverse();

                                        tmpRoute1.NodeAtEnd = tmpRoute2.NodeAtStart;
                                        tmpRoute1.Capacity += tmpRoute2.Capacity;
                                        tmpRoute1.Route.AddRange(tmpRoute2.Route);
                                        aRoutesList.RemoveAt(aRoutesList.IndexOf(tmpRoute2));

                                        aCoeffAndNodesList[j].Forbidden = true;

                                        RemoveFromDictionaryAndLists(aCoeffAndNodesList[i].StartingNode);
                                        RemoveFromDictionaryAndLists(aCoeffAndNodesList[i].EndingNode);

                                        tmpRouteFound = true;


                                    }
                                }


                            }
                            else
                            {
                                aCoeffAndNodesList[j].Forbidden = true;
                                //aCoeffAndNodesList.RemoveAt(i);

                                tmpRouteFound = true;

                                break;
                            }
                        }
                        else if (aRoutesList[j].NodeAtStart.Id == aCoeffAndNodesList[i].StartingNode.Id)
                        {
                            // Rotate and Add to Left

                            if (aRoutesList[j].Capacity + tmpCap1 + tmpCap2 <= tmpK)
                            {

                                AddRoute(j, true, aCoeffAndNodesList[i].EndingNode, tmpCap2 + tmpCap2);

                                RemoveFromDictionaryAndLists(aCoeffAndNodesList[i].StartingNode);

                                tmpRouteFound = true;

                                break;

                            }

                            aCoeffAndNodesList[j].Forbidden = true;
                            //aCoeffAndNodesList.RemoveAt(i);

                            tmpRouteFound = true;

                            break;

                        }
                        else if (aRoutesList[j].NodeAtStart.Id == aCoeffAndNodesList[i].EndingNode.Id)
                        {
                            // Add to Left

                            if (aRoutesList[j].Capacity + tmpCap1 + tmpCap2 <= tmpK)
                            {

                                AddRoute(j, true, aCoeffAndNodesList[i].StartingNode, tmpCap2 + tmpCap2);

                                RemoveFromDictionaryAndLists(aCoeffAndNodesList[i].EndingNode);

                                tmpRouteFound = true;

                                break;
                            }

                            //aCoeffAndNodesList.RemoveAt(i);
                            aCoeffAndNodesList[j].Forbidden = true;

                            tmpRouteFound = true;

                            break;

                        }
                        else if (aRoutesList[j].NodeAtEnd.Id == aCoeffAndNodesList[i].StartingNode.Id)
                        {
                            // Add to Right

                            if (aRoutesList[j].Capacity + tmpCap1 + tmpCap2 <= tmpK)
                            {

                                AddRoute(j, false, aCoeffAndNodesList[i].EndingNode, tmpCap2 + tmpCap2);

                                RemoveFromDictionaryAndLists(aCoeffAndNodesList[i].StartingNode);

                                tmpRouteFound = true;

                                break;
                            }

                            //aCoeffAndNodesList.RemoveAt(i);
                            aCoeffAndNodesList[j].Forbidden = true;

                            tmpRouteFound = true;

                            break;

                        }
                        else if (aRoutesList[j].NodeAtEnd.Id == aCoeffAndNodesList[i].EndingNode.Id)
                        {
                            // Rotate and Add to Right

                            if (aRoutesList[j].Capacity + tmpCap1 + tmpCap2 <= tmpK)
                            {

                                AddRoute(j, false, aCoeffAndNodesList[i].StartingNode, tmpCap2 + tmpCap2);

                                RemoveFromDictionaryAndLists(aCoeffAndNodesList[i].EndingNode);

                                tmpRouteFound = true;

                                break;
                            }

                            //aCoeffAndNodesList.RemoveAt(i);
                            aCoeffAndNodesList[j].Forbidden = true;

                            tmpRouteFound = true;

                            break;

                        }
                    }

                    if (!tmpRouteFound)
                    {

                        Routes tmpRoutes = new Routes(aCoeffAndNodesList[i].StartingNode, aCoeffAndNodesList[i].EndingNode, new List<Node>() { aCoeffAndNodesList[i].StartingNode, aCoeffAndNodesList[i].EndingNode }, tmpCap1 + tmpCap2);

                        aRoutesList.Add(tmpRoutes);

                        aDictionaryRoutePointers.Add(aCoeffAndNodesList[i].StartingNode, tmpRoutes);
                        aDictionaryRoutePointers.Add(aCoeffAndNodesList[i].EndingNode, tmpRoutes);

                        if (tmpK == tmpCap1 + tmpCap2)
                        {
                            RemoveFromDictionaryAndLists(aCoeffAndNodesList[i].StartingNode);
                            RemoveFromDictionaryAndLists(aCoeffAndNodesList[i].EndingNode);
                        }

                    }


                }

            }

            foreach (var tmpNodes in parListNodesWithoutPrimarySource)
            {
                if (!aDictionaryRoutePointers.ContainsKey(tmpNodes))
                {
                    aRoutesList.Add(new Routes(tmpNodes, null, new List<Node>() { tmpNodes }, tmpNodes.Capacity));
                }
            }


            return aRoutesList;

        }

        public void RemoveFromDictionaryAndLists(Node parNode)
        {

            if (parNode.Id == 6)
            {
                Console.WriteLine();
            }

            for (int j = 0; j < aCoeffAndNodesList.Count; j++)
            {
                if (aCoeffAndNodesList[j].StartingNode.Id == parNode.Id || aCoeffAndNodesList[j].EndingNode.Id ==
                    parNode.Id)
                {
                    // aCoeffAndNodesList.RemoveAt(j);
                    aCoeffAndNodesList[j].Forbidden = true;

                    if (!(j < aCoeffAndNodesList.Count))
                    {
                        break;
                    }
                }


            }

            aDictionaryOfAllowedCoeficients.Remove(parNode);
        }

        public void AddRoute(int parIndex, bool parAddAtStart, Node parNode, double parCapacity)
        {
            if (parAddAtStart)
            {
                aRoutesList[parIndex].Route.Insert(0, parNode);
                aRoutesList[parIndex].NodeAtStart = parNode;
            }
            else
            {
                aRoutesList[parIndex].Route.Add(parNode);
                aRoutesList[parIndex].NodeAtEnd = parNode;
            }

            aRoutesList[parIndex].Capacity += parCapacity;

            aDictionaryRoutePointers.Add(parNode, aRoutesList[parIndex]);


        }
    }
}
