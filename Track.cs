using System;

namespace RailSimulator
{
    public class Track
    {
        public Station Start { get; }
        public Station End { get; }
        private readonly double length;

        public Track(Station start, Station end, double legth)
        {
            this.Start = start;
            this.End = end;
            length = legth;
        }

        public bool IsConnectedWith(Station station1, Station station2)
        {
            return (Start == station1 && End == station2) || (Start == station2 && End == station1);
        }
    }
}