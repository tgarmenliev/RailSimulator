using System;

namespace RailSimulator
{
    public class Pair(double x, double y)
    {
        public double X { get; } = x;
        public double Y { get; } = y;

        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }
    }
}