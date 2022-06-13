using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace IOA___WinForms.MetodaSZRohu
{
    class SZCorner
    {
        private int[] aCustomerRequirements = new int[] { 110, 120, 130, 140 };
        private int[] aWarehousesCapacity = new int[] { 100, 100, 100, 100, 100 };

        public SZCorner()
        {
            int[,] tmpSolutionMatrix = new int[aCustomerRequirements.Length, aWarehousesCapacity.Length];

            int b;

            int i = 0;
            int j = 0;


            while (i != aCustomerRequirements.Length || j != aWarehousesCapacity.Length)
            {
                int tmpXrs = Math.Min(aCustomerRequirements[i], aWarehousesCapacity[j]);

                aCustomerRequirements[i] -= tmpXrs;
                aWarehousesCapacity[j] -= tmpXrs;

                tmpSolutionMatrix[i, j] = tmpXrs;

                EqualsZeroIncrement(aCustomerRequirements, ref i);
                EqualsZeroIncrement(aWarehousesCapacity, ref j);

             
            }


            for (int k = 0; k < tmpSolutionMatrix.GetLength(0); k++)
            {
                for (int l = 0; l < tmpSolutionMatrix.GetLength(1); l++)
                {
                    Debug.Write( String.Format("{0,6}", tmpSolutionMatrix[k, l]) + " ");
                }
                
                Debug.WriteLine("");
            }

            // Vypis som dal do Debug Outputu...


        }

        public bool EqualsZeroIncrement(int[] parArray, ref int parIndexAt)
        {
            if (parArray[parIndexAt] == 0)
            {
                parIndexAt++;
                return true;
            }

            return false;
        }


    }
}
