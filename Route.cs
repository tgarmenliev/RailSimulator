using System;
using System.Dynamic;

namespace RailSimulator
{
    public class Route
    {
        public List<RouteStop> Stops { get; } = new List<RouteStop>();
        private int currentStopIndex;
        public int CurrentStopIndex => currentStopIndex;
        public double Length { get; }

        public Route(List<RouteStop> stops)
        {
            Stops = stops;
            currentStopIndex = 0;
            Length = 0; //CalculateLength();
        }
        
        public List<string> GetStations()
        {
            return Stops.Select(stop => stop.Station).ToList();
        }

        public DateTime GetTime(string station, bool arrival)
        {
            return arrival ? Stops.First(stop => stop.Station == station).Arrival : Stops.First(stop => stop.Station == station).Departure;
        }
        
        public void AddStop(RouteStop stop)
        {
            Stops.Add(stop);
        }

        public string GetFirstStop()
        {
            return Stops.First().Station;
        }

        public string GetLastStop()
        {
            return Stops.Last().Station;
        }

        public DateTime CheckInAtStation(string station)
        {
            return GetCurrentStop().Departure;
        }

        public string CheckOutAtStation(string station)
        {
            currentStopIndex++;
            return GetCurrentStation();
        }
        public RouteStop GetCurrentStop()
        {
            return Stops[currentStopIndex];
        }

        public string GetCurrentStation()
        {
            return GetCurrentStop().Station;
        }
    }
}