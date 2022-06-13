using System;
using System.Collections.Generic;
using System.Text;

namespace IOA___WinForms.SemestralkaPart1
{
    public class Edge
    {
        private Node aFirstNode;

        private Node aSecondNode;

        private double aDistance;

        public Node FirstNode
        {
            get => aFirstNode;
            set => aFirstNode = value;
        }

        public Node SecondNode
        {
            get => aSecondNode;
            set => aSecondNode = value;
        }

        public double Distance
        {
            get => aDistance;
            set => aDistance = value;
        }

        public Edge(Node parAFirstNode, Node parASecondNode, double parADistance)
        {
            aFirstNode = parAFirstNode;
            aSecondNode = parASecondNode;
            aDistance = parADistance;
        }

        public Edge()
        {
        }


    }
}
