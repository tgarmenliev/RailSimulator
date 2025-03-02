using System;

namespace RailSimulator
{
    public class RouteStop(Station station, DateTime arrival, DateTime departure)
    {
        public Station Station { get; } = station;
        public DateTime Arrival { get; } = arrival;
        public DateTime Departure { get; } = departure;
        public bool IsPassed { get; } = false;

        public override string ToString()
        {
            return "Stop at station " + Station + " at " + Arrival + " and depart by " + Departure + ".";
        }
    }
}