using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace IOA___WinForms
{
    class PartialRecalculationsClass
    {
        private bool[] aWarehousesLocations;

        private double aCost;

        private PartialRecalculationsClass aLeftParent;

        private PartialRecalculationsClass aRightParent;

        public PartialRecalculationsClass(bool[] parAWarehousesLocations, double parACost, PartialRecalculationsClass parALeftParent = null, PartialRecalculationsClass parARightParent = null)
        {
            aWarehousesLocations = new bool[parAWarehousesLocations.Length];
            Array.Copy(parAWarehousesLocations, aWarehousesLocations, parAWarehousesLocations.Length);
            aCost = parACost;
            aLeftParent = parALeftParent;
            aRightParent = parARightParent;
        }

        public void AddParent(PartialRecalculationsClass parALeftParent, PartialRecalculationsClass parARightParent)
        {
            aLeftParent = parALeftParent;
            aRightParent = parARightParent;
        }

        public List<int> GetWareHouseLocAsIntegers()
        {
            List<int> tmpList = new List<int>(aWarehousesLocations.Length);

            for (int i = 0; i < aWarehousesLocations.Length; i++)
            {
                if (aWarehousesLocations[i])
                {
                    tmpList.Add(i + 1);
                }
            }

            return tmpList;
        }

        public bool[] WarehousesLocations
        {
            get => aWarehousesLocations;
            set => aWarehousesLocations = value;
        }

        public double Cost
        {
            get => aCost;
            set => aCost = value;
        }

        public PartialRecalculationsClass LeftParent
        {
            get => aLeftParent;
            set => aLeftParent = value;
        }

        public PartialRecalculationsClass RightParent
        {
            get => aRightParent;
            set => aRightParent = value;
        }


        public override string ToString()
        {

            string tmpReturnString = string.Empty;

            for (int i = 0; i < WarehousesLocations.Length; i++)
            {
                if (WarehousesLocations[i])
                {
                    tmpReturnString += i + " ";
                }
            }

            tmpReturnString += Cost + " " + " Left: " + aLeftParent + " Right: " + aRightParent;

            return tmpReturnString;
        }


        public int[] WarehousesBoolToInt()
        {
            List<int> tmpReturn = new List<int>();

            int tmpCounter = 1;
            for (int i = 0; i < WarehousesLocations.Length; i++)
            {
                if (WarehousesLocations[i])
                {
                    tmpReturn.Add(tmpCounter);
                }

                tmpCounter++;
            }

            return tmpReturn.ToArray();
        }

    }
}
