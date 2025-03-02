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
        
        public List<Station> GetStations()
        {
            return Stops.Select(stop => stop.Station).ToList();
        }

        //TODO
        public DateTime GetArrivalTime(Station station)
        {
            return Stops.Last(stop => stop.Station == station).Arrival;
        }

        //TODO
        public DateTime GetDepartureTime(Station station)
        {
            return Stops.First(stop => stop.Station == station).Departure;
        }
        
        public void AddStop(RouteStop stop)
        {
            Stops.Add(stop);
        }

        public Station GetFirstStop()
        {
            return Stops.First().Station;
        }

        public Station GetLastStop()
        {
            return Stops.Last().Station;
        }

        //TODO
        public DateTime CheckInAtStation(Station station)
        {
            return GetArrivalTime(station);
        }

        //TODO
        public Station CheckOutAtStation(Station station)
        {
            return station;
        }

        public void MoveToNextStop()
        {
            currentStopIndex++;
        }

        public RouteStop GetCurrentStop()
        {
            return Stops[currentStopIndex];
        }

        public Station GetCurrentStation()
        {
            return GetCurrentStop().Station;
        }
    }
}