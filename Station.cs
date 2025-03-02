using System;

namespace RailSimulator
{
    public abstract class Station
    {
        protected string name;
        protected Pair coordinates;
        protected List<bool> tracks;
        protected List<Train> trainsAtStation;

        protected List<Train> waitingTrains = new List<Train>();

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

        public void DepartTrain(Train train)
        {
            if(trainsAtStation.Contains(train))
            {
                trainsAtStation.Remove(train);
                if (train.Track.HasValue) ReleaseTrack(train.Track.Value);
            }
            train.Move();
        }

        public int? AssignTrackToTrain(Train train)
        {
            for (int i = 0; i < tracks.Count; i++)
            {
                if (!tracks[i]) // If we have a free track
                {
                    tracks[i] = true;
                    return i;
                }
            }
            return null; // There are no free tracks
        }

        public void ReleaseTrack(int trackNumber)
        {
            if (trackNumber >= 0 && trackNumber < Tracks.Count)
            {
                Tracks[trackNumber] = false;
                
                if (waitingTrains.Count > 0)
                {
                    Train nextTrain = waitingTrains[0];
                    waitingTrains.RemoveAt(0);
                    HandleTrainArrival(nextTrain);
                }
            }
        }

        public override string ToString()
        {
            return "Station " + Name + " at " + Coordinates + " with " + Tracks.Count + " tracks.";
        }
    }

    public class SmallStation : Station
    {

        public SmallStation(string name, Pair coordinates, int tracks) : base(name, coordinates, tracks)
        {
        }

        public override void HandleTrainArrival(Train train)
        {
            // Fast and express trains do not stop at small stations
            if (train.Type == TrainType.Fast || train.Type == TrainType.Express)
            {
                return;
            }

            int? assignedTrack = AssignTrackToTrain(train);

            if (assignedTrack.HasValue)
            {
                train.Track = assignedTrack; // Track is assigned to the train
                TrainsAtStation.Add(train);
                return;
            }

            // If no track is available, the train is added to the waiting list
            waitingTrains.Add(train);
            waitingTrains = waitingTrains.OrderBy(t => t.Route.GetTime(Name, true)).ToList();
        }

        public override string ToString()
        {
            return "Small station " + Name + " at " + Coordinates + ".";
        }
    }
}