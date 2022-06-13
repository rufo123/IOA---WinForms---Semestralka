using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace IOA___WinForms.SemestralkaPart1
{

    public enum NodeType
    {
        PrimarySource = 1,
        Customer = 2,
        PossibleTransShipLocation = 3,
        Unspecified = 0
    }

    public class Node : IComparable
    {

        private NodeType aNodeType;

        private double aCapacity;

        public int aId;

        private Vector2 aCoordinates;

        private bool aClicked;

        public NodeType NodeType
        {
            get => aNodeType;
            set => aNodeType = value;
        }

        public double Capacity
        {
            get => aCapacity;
            set => aCapacity = value;
        }

        public int Id
        {
            get => aId;
            set => aId = value;
        }

        public Vector2 Coordinates
        {
            get => aCoordinates;
            set => aCoordinates = value;
        }

        public bool Clicked
        {
            get => aClicked;
            set => aClicked = value;
        }

        public Node(NodeType parANodeType, double parACapacity, int parId, Vector2 parCoordinates)
        {
            aNodeType = parANodeType;
            aCapacity = parACapacity;
            aId = parId;
            aCoordinates = parCoordinates;
        }


        public Node(double parACapacity, int parId, Vector2 parCoordinates)
        {
            aNodeType = NodeType.Unspecified;
            aCapacity = parACapacity;
            aId = parId;
            aCoordinates = parCoordinates;
        }

        public Node()
        {
            aNodeType = NodeType.Unspecified;
        }


        public int CompareTo(object? obj)
        {
            if (obj is Node)
            {
                return this.Id.CompareTo(((Node) obj).Id);
            }
            else
            {
                throw new ArgumentException("Type: " + obj.GetType() + " is not Node");
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is Node)
            {
                return this.Id.CompareTo(((Node)obj).Id) == 0;
            }
            else
            {
                throw new ArgumentException("Type: " + obj.GetType() + " is not Node");
            }
        }

        public override string ToString()
        {
            return "Id: " + aId + "XY: " + Coordinates + "Type: " + aNodeType + "Cap: " + Capacity;
        }
    }
}
