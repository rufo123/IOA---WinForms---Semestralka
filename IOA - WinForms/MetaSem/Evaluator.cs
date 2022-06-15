using System;
using System.Collections.Generic;
using System.Text;

namespace IOA___WinForms.MetaSem
{
    class Evaluator
    {
        public Evaluator()
        {
        }

        public double Cost(List<int> par1, Dictionary<int, MetaNode> parDictionaryMetaNodes)
        {
            return MetaMain.CalculateRouteCost(par1, parDictionaryMetaNodes);
        }


    }
}
