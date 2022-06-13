using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace IOA___WinForms.SemestralkaPart1
{
    public class Routes
    {
        private Node aNodeAtStart;

        private Node aNodeAtEnd;

        private List<Node> aRoute;

        private double aCapacity;

        private Random aRandomGenerator;

        private Random aRandomSeedGenerator;

        private Color aDrawnRouteColor;

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

        public Color DrawnRouteColor
        {
            get => aDrawnRouteColor;
            set => aDrawnRouteColor = value;
        }

        public Routes(Node parANodeAtStart, Node parANodeAtEnd, List<Node> parARoute, double parACapacity)
        {
            aNodeAtStart = parANodeAtStart;
            aNodeAtEnd = parANodeAtEnd;
            aRoute = parARoute;
            aCapacity = parACapacity;

            aRandomSeedGenerator = new Random();
            aRandomGenerator = new Random(aRandomSeedGenerator.Next());

            aDrawnRouteColor = Color.FromArgb(aRandomGenerator.Next(255), aRandomGenerator.Next(255), aRandomGenerator.Next(255));
        }

        public Routes()
        {

        }
    }
}
