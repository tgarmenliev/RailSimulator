using System;

namespace RailSimulator
{
    public class Track
    {
        public Station Start { get; }
        public Station End { get; }
        public int maxSpeed { get; private set; }
        private double length;

        public Track(Station start, Station end, int maxSpeed, double legth)
        {
            Start = start;
            End = end;
            this.maxSpeed = maxSpeed;
            this.length = legth;
        }

        public bool IsConnectedWith(Station station1, Station station2)
        {
            return (Start == station1 && End == station2) || (Start == station2 && End == station1);
        }
    }
}