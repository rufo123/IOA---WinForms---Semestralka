using System;
using System.Collections.Generic;
using System.Text;

namespace IOA___WinForms.SemestralkaPart1
{
    public class CoefficientAndNodes : IComparable
    {
        private double aCoefficient;

        private Node aStartingNode;

        private Node aEndingNode;

        public double Coefficient => aCoefficient;

        public Node StartingNode => aStartingNode;

        public Node EndingNode => aEndingNode;

        private bool aForbidden;

        public bool Forbidden
        {
            get => aForbidden;
            set => aForbidden = value;
        }


        public CoefficientAndNodes(double parACoefficient, Node parAStartingNode, Node parAEndingNode)
        {
            aCoefficient = parACoefficient;
            aStartingNode = parAStartingNode;
            aEndingNode = parAEndingNode;
        }


        public int CompareTo(object? obj)
        {
            if (obj is CoefficientAndNodes)
            {
                CoefficientAndNodes tmpCompare = (CoefficientAndNodes) obj;

                if (aCoefficient.CompareTo(tmpCompare.Coefficient) == 0)
                {
                    return aStartingNode.CompareTo(tmpCompare.StartingNode);
                }

                return aCoefficient.CompareTo(tmpCompare.Coefficient);

            }
            else
            {
                throw new ArgumentException("Object is not CoefficientAndNodes");
            }

        }
    }
}
