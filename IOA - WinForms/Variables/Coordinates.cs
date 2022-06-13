using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathIOA
{
    class Coordinates
    {
        public Coordinates(int parX, int parY)
        {
            this.X = parX;
            this.Y = parY;
        }

        private int aX;
        private int aY;

        public int X
        {
            get => aX;
            set => aX = value;
        }

        public int Y
        {
            get => aY;
            set => aY = value;
        }

        public override string ToString()
        {
            return this.X + " , " + this.Y;
        }
    }
}
