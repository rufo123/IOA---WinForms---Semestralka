using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathIOA.ForwardStar_
{
    public class ForwardStarItem : IComparable, IComparer<ForwardStarItem>
    {

        private int aEndNode;

        private double aDistance;

        private int aInitialNode;

        public ForwardStarItem(int parEndNode, double parDistance, int parInitialNode)
        {
            this.aEndNode = parEndNode;
            this.aDistance = parDistance;
            this.aInitialNode = parInitialNode;
        }

        public int EndNode
        {
            get => aEndNode;
            set => aEndNode = value;
        }

        public double Distance
        {
            get => aDistance;
            set => aDistance = value;
        }

        public int InitialNode
        {
            get => aInitialNode;
            set => aInitialNode = value;
        }

        public int Compare(ForwardStarItem? tmpItemOne, ForwardStarItem? tmpItemTwo)
        {

            if (tmpItemOne == null && tmpItemTwo == null)
            {
                return 0;
            }

            if (tmpItemOne.InitialNode.CompareTo(tmpItemTwo.aInitialNode) == 0)
            {
                if (tmpItemOne.EndNode.CompareTo(tmpItemTwo.EndNode) == 0)
                {
                    return tmpItemOne.Distance.CompareTo(tmpItemTwo.Distance);

                }

                return tmpItemOne.EndNode.CompareTo(tmpItemTwo.EndNode);
            }

            return tmpItemOne.InitialNode.CompareTo(tmpItemTwo.InitialNode);
        }

        public override string ToString()
        {
            return EndNode + " " + Distance + " " + InitialNode;
        }

        public int CompareTo(object? obj)
        {
            if (obj is ForwardStarItem)
            {
                ForwardStarItem tmpItem = (ForwardStarItem)obj;
                if (aInitialNode.CompareTo(tmpItem.aInitialNode) == 0)
                {
                    if (aEndNode.CompareTo(tmpItem.EndNode) == 0)
                    {
                        return aDistance.CompareTo(tmpItem.Distance);

                    }
                    return aEndNode.CompareTo(tmpItem.EndNode);
                }
                return aInitialNode.CompareTo(tmpItem.InitialNode);
            }

            throw new ArgumentException("Type: " + obj.GetType() + " is not ForwardStarItem");
        }
    }
}
