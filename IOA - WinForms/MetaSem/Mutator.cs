using System;
using System.Collections.Generic;
using System.Text;

namespace IOA___WinForms.MetaSem
{
    class Mutator
    {

        private Random aRandom;
        private Random aRandomFirst;
        private Random aRandomSecond;

        public Mutator()
        {
            aRandom = new Random();
            aRandomFirst = new Random();
            aRandomSecond = new Random();

        }

        public void Mutate(List<int> par1)
        {
            if (aRandom.NextDouble() < 0.5)
            {
                int tmpFirst = aRandomFirst.Next(par1.Count);
                int tmpSecond = aRandomSecond.Next(par1.Count);

                while (tmpFirst == tmpSecond)
                {
                    tmpSecond = aRandomSecond.Next(par1.Count);
                }

                int tmpHelper = par1[tmpFirst];
                par1[tmpFirst] = par1[tmpSecond];
                par1[tmpSecond] = tmpHelper;
            }
        }
    }
}
