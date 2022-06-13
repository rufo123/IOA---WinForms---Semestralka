using System;
using System.Collections.Generic;
using System.Text;

namespace IOA___WinForms.SemestralkaPart1.ForwardStarSemestralka
{
    public class ForwardStarItemSem : IComparable
    {
        private Node aEndNode;

        private double aDistance;

        private Node aInitialNode;

        public ForwardStarItemSem(Node parEndNode, double parDistance, Node parInitialNode)
        {
            this.aEndNode = parEndNode;
            this.aDistance = parDistance;
            this.aInitialNode = parInitialNode;
        }

        public Node EndNode
        {
            get => aEndNode;
            set => aEndNode = value;
        }

        public double Distance
        {
            get => aDistance;
            set => aDistance = value;
        }

        public Node InitialNode
        {
            get => aInitialNode;
            set => aInitialNode = value;
        }

        public int Compare(ForwardStarItemSem? tmpItemOne, ForwardStarItemSem? tmpItemTwo)
        {

            if (tmpItemOne == null && tmpItemTwo == null)
            {
                return 0;
            }

            if (tmpItemOne.InitialNode.Id.CompareTo(tmpItemTwo.aInitialNode) == 0)
            {
                if (tmpItemOne.EndNode.Id.CompareTo(tmpItemTwo.EndNode) == 0)
                {
                    return tmpItemOne.Distance.CompareTo(tmpItemTwo.Distance);

                }

                return tmpItemOne.EndNode.Id.CompareTo(tmpItemTwo.EndNode);
            }

            return tmpItemOne.InitialNode.Id.CompareTo(tmpItemTwo.InitialNode);
        }

        public override string ToString()
        {
            return EndNode + " " + Distance + " " + InitialNode;
        }

        public int CompareTo(object? obj)
        {
            if (obj is ForwardStarItemSem)
            {
                ForwardStarItemSem tmpItem = (ForwardStarItemSem)obj;
                if (aInitialNode.Id.CompareTo(tmpItem.aInitialNode.Id) == 0)
                {
                    if (aEndNode == null && tmpItem.EndNode == null)
                    {
                        return 0;
                    }

                    if (aEndNode != null && tmpItem.EndNode == null)
                    {
                        return -1;
                    }

                    if (aEndNode == null && tmpItem.EndNode != null)
                    {
                        return 1;
                    }

                    if (aEndNode.Id.CompareTo(tmpItem.EndNode.Id) == 0)
                    {
                        return aDistance.CompareTo(tmpItem.Distance);

                    }
                    return aEndNode.Id.CompareTo(tmpItem.EndNode.Id);
                }
                return aInitialNode.Id.CompareTo(tmpItem.InitialNode.Id);
            }

            throw new ArgumentException("Type: " + obj.GetType() + " is not ForwardStarItem");
        }
    }
}
