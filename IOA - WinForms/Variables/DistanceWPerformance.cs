using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathIOA
{
    public class DistanceWPerformance
    {
        private double aDistance;
        private int aPerformance;

        public double Distance
        {
            get => aDistance;
            set => aDistance = value;
        }

        public int Performance
        {
            get => aPerformance;
            set => aPerformance = value;
        }

        public DistanceWPerformance(double parDistance, int parPerformance)
        {
            this.aDistance = parDistance;
            this.aPerformance = parPerformance;
        }

        public override string ToString()
        {
            return Distance + " " + Performance;
        }
    }
}
