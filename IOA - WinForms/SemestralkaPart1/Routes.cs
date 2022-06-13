using System;
using System.Collections.Generic;
using System.Text;

namespace IOA___WinForms.SemestralkaPart1
{
    public class Routes
    {
        private Node aNodeAtStart;

        private Node aNodeAtEnd;

        private List<Node> aRoute;

        private double aCapacity;

        public Node NodeAtStart
        {
            get => aNodeAtStart;
            set => aNodeAtStart = value;
        }

        public Node NodeAtEnd
        {
            get => aNodeAtEnd;
            set => aNodeAtEnd = value;
        }

        public List<Node> Route
        {
            get => aRoute;
            set => aRoute = value;
        }

        public double Capacity
        {
            get => aCapacity;
            set => aCapacity = value;
        }

        public Routes(Node parANodeAtStart, Node parANodeAtEnd, List<Node> parARoute, double parACapacity)
        {
            aNodeAtStart = parANodeAtStart;
            aNodeAtEnd = parANodeAtEnd;
            aRoute = parARoute;
            aCapacity = parACapacity;
        }
    }
}
