using System;
using System.Collections.Generic;
using System.Text;

namespace IOA___WinForms.SemestralkaPart1.ForwardStarShortest
{
    public class ForwardStartItemShortest : IComparable
    {
        private Node aStartingNode;

        private Node aEndingNode;

        private double aShortestPathCost;

        public Node StartingNode
        {
            get => aStartingNode;
            set => aStartingNode = value;
        }

        public Node EndingNode
        {
            get => aEndingNode;
            set => aEndingNode = value;
        }

        public double ShortestPathCost
        {
            get => aShortestPathCost;
            set => aShortestPathCost = value;
        }

        public ForwardStartItemShortest(Node parStartingNode, Node parEndingNode, double parShortestPathCost)
        {
            aStartingNode = parStartingNode;
            aEndingNode = parEndingNode;
            aShortestPathCost = parShortestPathCost;
        }

        public int CompareTo(object? obj)
        {
            if (obj is ForwardStartItemShortest)
            {
                ForwardStartItemShortest tmpItem = (ForwardStartItemShortest)obj;
                if (aStartingNode.Id.CompareTo(tmpItem.aStartingNode.Id) == 0)
                {
                    if (aEndingNode == null && tmpItem.aEndingNode == null)
                    {
                        return 0;
                    }

                    if (aEndingNode != null && tmpItem.aEndingNode == null)
                    {
                        return -1;
                    }

                    if (aEndingNode == null && tmpItem.aEndingNode != null)
                    {
                        return 1;
                    }

                    if (aEndingNode.Id.CompareTo(tmpItem.aEndingNode.Id) == 0)
                    {
                        return aShortestPathCost.CompareTo(tmpItem.aShortestPathCost);

                    }
                    return aEndingNode.Id.CompareTo(tmpItem.aEndingNode.Id);
                }
                return aStartingNode.Id.CompareTo(tmpItem.aStartingNode.Id);
            }

            throw new ArgumentException("Type: " + obj.GetType() + " is not ForwardStarItem");
        }

     


    }
}
