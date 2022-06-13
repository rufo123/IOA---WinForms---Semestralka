using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using ShortestPathIOA;
using ShortestPathIOA.ForwardStar_;

namespace IOA___WinForms
{
    class PartialRecalculationsMethod
    {
        private ForwardStar aStar;

        private int[] aSklady;
        private bool[] aUmiestneniaSkladov;

        private int[] aNaklady;
        private int aJednotkoveNaklady;
        private int[] aZakaznici;
        private int[] aPoziadavkyZakaznikov;

        private double[,] aDistance;

        private Dictionary<int, List<PartialRecalculationsClass>> aDictionaryMetodaCiastFx;

        public ForwardStar Star
        {
            get => aStar;
            set => aStar = value;
        }

        public void LoadStar()
        {
            int tmpCountNodes = 10;

            int tmpLoadedConnected = -1;

            ForwardStar tmpStar = new ForwardStar(tmpCountNodes);

            // Dictionary<int, Vector2> tmpCoordinates = new Dictionary<int, Vector2>(tmpCountNodes);

            int tmpCountOfMaxConnected = ((tmpCountNodes - 1) * (tmpCountNodes)) / 2;

            ConnectedEdges[] tmpConnectedEdges = new ConnectedEdges[tmpCountOfMaxConnected];

            using (StreamReader file = new StreamReader(@"SietMetodaCiastnocnych/vrcholy_spoj_cena.txt"))
            {
                int counter = 0;
                string ln;


                while ((ln = file.ReadLine()) != null)
                {

                    string[] tmpConnectedString = ln.Split(',');
                    tmpConnectedEdges[counter] = new ConnectedEdges(Int32.Parse(tmpConnectedString[0]), Int32.Parse(tmpConnectedString[1]));

                    Vector2 tmpCoordinate1 = new Vector2();
                    Vector2 tmpCoordinate2 = new Vector2();

                    tmpStar.Add(Int32.Parse(tmpConnectedString[0]), Int32.Parse(tmpConnectedString[1]), Int32.Parse(tmpConnectedString[2]));
                    tmpStar.Add(Int32.Parse(tmpConnectedString[1]), Int32.Parse(tmpConnectedString[0]), Int32.Parse(tmpConnectedString[2]));


                    counter++;
                    tmpLoadedConnected = counter;
                }
                file.Close();
            }


            tmpStar.Finalise();

            aStar = tmpStar;

        }

        public PartialRecalculationsMethod()
        {
            LoadStar();

            aSklady = new int[4];
            aUmiestneniaSkladov = new bool[4];

            aZakaznici = new int[9];

            aJednotkoveNaklady = 1;

            for (int i = 0; i < aSklady.Length; i++)
            {
                aSklady[i] = i + 1;
            }

            for (int i = 1; i < aZakaznici.Length; i++)
            {
                aZakaznici[i] = i + 1;
            }

            aPoziadavkyZakaznikov = new[] { 10, 30, 40, 20, 10, 20, 50, 30, 10, 20 };
            aNaklady = new[] { 200, 300, 300, 100 };

            aDistance = new double[,]
            {
                { 0, 31.66, 61.66, 84.02, 96.88, 100.38, 64.33, 36.05, 77.28 },
                { 31.66, 0, 30.0, 52.36, 66.05, 86.69, 50.64, 22.36, 63.589999999999996 },
                { 61.66, 30.0, 0, 22.36, 36.05, 113.33, 77.28, 52.36, 93.59 },
                { 84.02, 52.36, 22.36, 0, 58.41, 135.69, 99.63999999999999, 74.72, 115.94999999999999 },
                { 96.88, 66.05, 36.05, 58.41, 0, 77.28, 41.23, 60.83, 77.28 },
                { 100.38, 86.69, 113.33, 135.69, 77.28, 0, 36.05, 64.33, 72.1 },
                { 64.33, 50.64, 77.28, 99.63999999999999, 41.23, 36.05, 0, 28.28, 36.05 },
                { 36.05, 22.36, 52.36, 74.72, 60.83, 64.33, 28.28, 0, 41.23 },
                { 77.28, 63.589999999999996, 93.59, 115.94999999999999, 77.28, 72.1, 36.05, 41.23, 0 }
            };


            aDictionaryMetodaCiastFx = new Dictionary<int, List<PartialRecalculationsClass>>();

            PartialRecalculations();
        }

        public double CalculateCostFunction(bool[] parWarehousesPositions)
        {
            double tmpCostFunction = 0;



            for (int i = 0; i < parWarehousesPositions.Length; i++)
            {
                tmpCostFunction += aNaklady[i] * (parWarehousesPositions[i] ? 1 : 0);
            }


            for (int j = 0; j < aZakaznici.Length; j++)
            {
                int tmpMinJ = -1;
                int tmpMinI = -1;

                double tmpMin = double.MaxValue;

                for (int i = 0; i < parWarehousesPositions.Length; i++)
                {
                    if (aDistance[i, j] + aPoziadavkyZakaznikov[j] * 1 < tmpMin && parWarehousesPositions[i])
                    {
                        tmpMin = aDistance[i, j] + aPoziadavkyZakaznikov[j] * 1;
                        tmpMinI = i;
                        tmpMinJ = j;
                    }
                }

                tmpCostFunction += tmpMin;
            }


            return tmpCostFunction;

        }

        public void PartialRecalculations()
        {

            int k = 0;

            bool[] tmpWarehousesPositionsBackup = new bool[aUmiestneniaSkladov.Length];

            bool[] tmpWarehousesPositions = new bool[aUmiestneniaSkladov.Length];

            double tmpCost = 0;


            k = 0;

            for (int i = 0; i < aUmiestneniaSkladov.Length; i++)
            {
                tmpWarehousesPositions[i] = true;
                tmpCost = CalculateCostFunction(tmpWarehousesPositions);

                AddMetodaFx(k + 1, tmpCost, tmpWarehousesPositions);

                tmpWarehousesPositions[i] = false;

            }

            k = 1;

            while (k < aSklady.Length)
            {

                int tmpCurrentNeightSize = k + 1;

                Combination(aDictionaryMetodaCiastFx[k], tmpCurrentNeightSize);
                


            /*    foreach (MetodaCiastnosnychFx[] tmpItem in CombinationsRosettaWoRecursion(aDictionaryMetodaCiastFx[k].ToArray(), tmpCurrentNeightSize))
                {
                    bool[] tmpWarehousesLoc = new bool[aUmiestneniaSkladov.Length];

                    MetodaCiastnosnychFx tmpParent1 = null;
                    MetodaCiastnosnychFx tmpParent2 = null;

                    for (int i = 0; i < tmpItem.Length; i++)
                    {



                        for (int j = 0; j < tmpItem[i].WarehousesLocations.Length; j++)
                        {
                            if (tmpItem[i].WarehousesLocations[j])
                            {
                                tmpWarehousesLoc[j] = true;
                            }

                        }

                    }

                    tmpCost = CalculateCostFunction(tmpWarehousesLoc);

                    tmpParent1 = tmpItem[0];
                    tmpParent2 = tmpItem[1];

                    if (tmpParent2.Cost > tmpCost || tmpParent1.Cost > tmpCost)
                    {
                        AddMetodaFx(tmpCurrentNeightSize, tmpCost, tmpWarehousesLoc, tmpParent1, tmpParent2);
                    }


                }
            */

                if (!aDictionaryMetodaCiastFx.ContainsKey(k + 1) || aDictionaryMetodaCiastFx[k + 1].Count < 2)
                {
                    break;
                }


                k = k + 1;
            }


            double tmpMin = Double.MaxValue;
            List<int> tmpWarehouses = new List<int>();

            for (int i = 1; i <= aDictionaryMetodaCiastFx.Count; i++)
            {
                List<PartialRecalculationsClass> tmpList = aDictionaryMetodaCiastFx[i];

                for (int j = 0; j < tmpList.Count; j++)
                {
                    if (tmpList[j].Cost < tmpMin)
                    {
                        tmpMin = tmpList[j].Cost;
                        tmpWarehouses = tmpList[j].GetWareHouseLocAsIntegers();
                    }
                }
            }

            string tmpReturn = string.Empty;

            for (int i = 0; i < tmpWarehouses.Count; i++)
            {
                if (tmpWarehouses.Count - 1 == i)
                {
                    tmpReturn += tmpWarehouses[i];
                }
                else
                {
                    tmpReturn += tmpWarehouses[i] + ", ";
                }

                
            }

            // Vypis musim davať do debug výstupu, z nejakeho dôvodu mi nejde zapnut Konzola...

            Debug.WriteLine("Najlepšie umiestnenie skladov je: [" + tmpReturn + "] s účelovou funkciou: " + tmpMin);

        }




        public void AddMetodaFx(int parCardinality, double parCostFunction, bool[] tmpWarehousesLocations, PartialRecalculationsClass parLeftParent = null, PartialRecalculationsClass parRightParent = null)
        {
            if (!aDictionaryMetodaCiastFx.ContainsKey(parCardinality))
            {
                aDictionaryMetodaCiastFx.Add(parCardinality, new List<PartialRecalculationsClass>()
                {
                    new PartialRecalculationsClass(tmpWarehousesLocations, parCostFunction, parLeftParent, parRightParent)
                });

            }
            else
            {
                List<PartialRecalculationsClass> tmpList = null;
                aDictionaryMetodaCiastFx.TryGetValue(parCardinality, out tmpList);
                tmpList?.Add(new PartialRecalculationsClass(tmpWarehousesLocations, parCostFunction, parLeftParent, parRightParent));
            }
        }


        public void Combination(List<PartialRecalculationsClass> parList, int tmpNewKSize)
        {
            List<int[]> tmpReturn = new List<int[]>();

            for (int i = 0; i < parList.Count - 1; i++)
            {
                for (int j = i + 1; j < parList.Count; j++)
                {

                    int[] tmpCombinedArray = null;

                    if (CombineIfCanBeCombined(parList[i].WarehousesBoolToInt(), parList[j].WarehousesBoolToInt(), out tmpCombinedArray))
                    {
                        AlgorithmRecalculations(ConvertIntArrayToBoolArrayWarehouses(tmpCombinedArray), parList[i], parList[j], tmpNewKSize);
                    }

                }
            }
        }

        public bool CombineIfCanBeCombined(int[] parWareHouse1, int[] parWareHouse2, out int[] parOutCombinedArray)
        {

            if (parWareHouse1.Length == parWareHouse2.Length)
            {

                if (parWareHouse1.Intersect(parWareHouse2).Count() == parWareHouse1.Length - 1)
                {
                    parOutCombinedArray = parWareHouse1.Union(parWareHouse2).ToArray();
                    return true;
                }

            }

            parOutCombinedArray = null;
            return false;
        }


        public void AlgorithmRecalculations(bool[] tmpCombinedWarehouse, PartialRecalculationsClass parParent1, PartialRecalculationsClass parParent2, int tmpCurrentKSize)
        {
            bool[] tmpWarehousesLoc = tmpCombinedWarehouse;

            double tmpCost = Double.NaN;

            tmpCost = CalculateCostFunction(tmpWarehousesLoc);

            if (parParent2.Cost > tmpCost || parParent1.Cost > tmpCost)
            {
                AddMetodaFx(tmpCurrentKSize, tmpCost, tmpWarehousesLoc, parParent1, parParent2);
            }
        }


        public bool[] ConvertIntArrayToBoolArrayWarehouses(int[] parWarehousesIntArray)
        {
            bool[] tmpReturnArray = new bool[aUmiestneniaSkladov.Length];

            foreach (var tmpItem in parWarehousesIntArray)
            {
                tmpReturnArray[tmpItem - 1] = true;
            }

            return tmpReturnArray;
        }





    }

}


