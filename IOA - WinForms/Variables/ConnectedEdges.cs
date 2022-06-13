using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathIOA
{
    public class ConnectedEdges
    {
        public int aFirstEdge;
        public int aSecondEdge;

        public int FirstEdge
        {
            get => aFirstEdge;
            set => aFirstEdge = value;
        }

        public int SecondEdge
        {
            get => aSecondEdge;
            set => aSecondEdge = value;
        }

        public ConnectedEdges(int parFirstEdge, int parSecondEdge)
        {
            this.aFirstEdge = parFirstEdge;
            this.aSecondEdge = parSecondEdge;
        }

        public ConnectedEdges()
        {
            this.aFirstEdge = -1;
            this.aSecondEdge = -1;
        }

        public ConnectedEdges Swap()
        {
            return new ConnectedEdges(aSecondEdge, aFirstEdge);
        }

        public override string ToString()
        {
            return this.FirstEdge + " , " + this.SecondEdge;
        }


    }
}
