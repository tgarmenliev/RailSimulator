using System;

namespace RailSimulator
{
    public abstract class Station
    {
        protected string name;
        protected Pair coordinates;
        protected List<bool> tracks;
        protected List<Train> trainsAtStation;

        public Station(string name, Pair coordinates, List<bool> tracks)
        {
            this.name = name;
            this.coordinates = coordinates;
            this.tracks = tracks;
            trainsAtStation = new List<Train>();
        }

        public Station(string name, Pair coordinates, int tracks)
        {
            this.name = name;
            this.coordinates = coordinates;
            this.tracks = new List<bool>(tracks);
            trainsAtStation = new List<Train>();
        }

        public string Name
        {
            get { return name; }
        }

        public Pair Coordinates
        {
            get { return coordinates; }
        }

        public List<bool> Tracks
        {
            get { return tracks; }
        }

        public List<Train> TrainsAtStation
        {
            get { return trainsAtStation; }
        }

        public abstract void HandleTrainArrival(Train train);

        // TODO
        public void DepartTrain(Train train)
        {
            return;
        }

        // TODO
        public int? AssignTrackToTrain(Train train)
        {
            return null;
        }

        // TODO
        public void ReleaseTrack(int trackNumber)
        {
            return;
        }

        public override string ToString()
        {
            return "Station " + Name + " at " + Coordinates + " with " + Tracks.Count + " tracks.";
        }
    }

    public class SmallStation : Station
    {

        public SmallStation(string name, Pair coordinates, List<bool> tracks) : base(name, coordinates, tracks)
        {
        }

        public SmallStation(string name, Pair coordinates, int tracks) : base(name, coordinates, tracks)
        {
        }

        // TODO
        public override void HandleTrainArrival(Train train)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "Small station " + Name + " at " + Coordinates + ".";
        }
    }
}