using System;

namespace RailSimulator
{
    class Program
    {
        private static void Main(string[] args)
        {
            RailwaySystem railwaySystem = new RailwaySystem();
            railwaySystem.AddStation(new SmallStation("S1", new Pair(0, 0), 1));
            railwaySystem.AddStation(new SmallStation("S2", new Pair(1, 0), 1));
            railwaySystem.AddStation(new SmallStation("S3", new Pair(2, 0), 1));
            railwaySystem.ConnectStations("S1", "S2", 1);
            railwaySystem.ConnectStations("S2", "S3", 1);
        }
    }
}