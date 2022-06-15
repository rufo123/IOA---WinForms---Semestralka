using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace IOA___WinForms.MetaSem
{
    class Crossover
    {
        private Random aRandom;

        public Crossover()
        {
            aRandom = new Random();
        }

        public List<List<int>> ToCross(List<int> par1, List<int> par2)
        {


            // Deep Copies

            List<int> tmp1 = new List<int>(par1.Capacity);
            List<int> tmp2 = new List<int>(par2.Capacity);

            for (int i = 0; i < par1.Count; i++)
            {
                tmp1.Add(par1[i]);
            }

            for (int i = 0; i < par1.Count; i++)
            {
                tmp2.Add(par2[i]);
            }


            int p = 0;
            int r = 0;
            do
            {
                p = aRandom.Next(tmp1.Count - 1);
                r = aRandom.Next(tmp2.Count - 1);

                if (p > r)
                {
                    int tmpHelp = p;
                    r = p;
                    p = tmpHelp;
                }
            } while (p == r);




            Debug.WriteLine(tmp1);
            Debug.WriteLine(tmp2);

            MetaMain.ContinuityChecker(tmp1);
            MetaMain.ContinuityChecker(tmp2);

            for (int i = p; i < r; i++)
            {


                MetaMain.ContinuityChecker(tmp1);
                MetaMain.ContinuityChecker(tmp2);

                int tmpIndex = -1;

                // Check For Uniqueness Pop 1

            /*    int tmpHelperIndex = par1.IndexOf(par2[i]);
                int tmpHelperIndex2 = par2.IndexOf(par1[i]);

                int test1 = tmpHelperIndex;
                int test2 = tmpHelperIndex2;


                bool tmpPreslo1 = false;

                if (tmpHelperIndex != -1 && tmpHelperIndex2 != -1)
                {
                    if ((tmpHelperIndex < p || tmpHelperIndex >= r) && (tmpHelperIndex2 < p || tmpHelperIndex2 >= r))
                    {
                        //Swap

                        int tmpHelp = par1[tmpHelperIndex];

                        par1[tmpHelperIndex] = par2[tmpHelperIndex2];

                        par2[tmpHelperIndex2] = tmpHelp;

                        tmpPreslo1 = true;

                    }
                }
            */
              


                int tmpHelper = tmp1[i];
                tmp1[i] = tmp2[i];
                tmp2[i] = tmpHelper;

                List<int> res = Enumerable.Range(0, tmp1.Count).Where(j => tmp1[j] == tmp1[i]).ToList().Where(x => x != i).ToList();
                List<int> res2 = Enumerable.Range(0, tmp2.Count).Where(j => tmp2[j] == tmp2[i]).ToList().Where(x => x != i).ToList();
                do
                {

                    if (res.Count > 0)
                    {
                        int tmpHelp = tmp1[res[0]];
                        tmp1[res[0]] = tmp2[res2[0]];
                        tmp2[res2[0]] = tmpHelp;

                    }

                    if (res2.Count > 0)
                    {
                       
                    }

                    res = Enumerable.Range(0, tmp1.Count).Where(j => tmp1[j] == tmp1[i]).ToList().Where(x => x != i).ToList();
                    res2 = Enumerable.Range(0, tmp2.Count).Where(j => tmp2[j] == tmp2[i]).ToList().Where(x => x != i).ToList();
                    
                }
                while (res.Count > 0 || res2.Count > 0);


                MetaMain.ContinuityChecker(tmp1);
                MetaMain.ContinuityChecker(tmp2);

            }

            MetaMain.ContinuityChecker(tmp1);
            MetaMain.ContinuityChecker(tmp2);

            Debug.WriteLine(tmp1);
            Debug.WriteLine(tmp2);



            return new List<List<int>>() { tmp1, tmp2 };

        }
    }


}
