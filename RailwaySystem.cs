namespace RailSimulator
{
    public class RailwaySystem
    {
        private List<Station> stations;
        private List<Track> tracks;
        private List<Train> trains;

        public RailwaySystem()
        {
            stations = new List<Station>();
            tracks = new List<Track>();
            trains = new List<Train>();
        }

        public List<Station> Stations
        {
            get { return stations; }
        }

        public List<Track> Tracks
        {
            get { return tracks; }
        }

        public List<Train> Trains
        {
            get { return trains; }
        }

        public void AddStation(Station station)
        {
            stations.Add(station);
        }

        private bool CheckTrack(Station station1, Station station2)
        {
            return tracks.Exists(track => track.IsConnectedWith(station1, station2));
        }

        private void AddTrack(Track track)
        {
            tracks.Add(track);
        }

        public void ConnectStations(string station1, string station2, double length)
        {
            Station? station1ToConnect = stations.Find(station => station.Name == station1);
            Station? station2ToConnect = stations.Find(station => station.Name == station2);
            if (station1ToConnect != null && station2ToConnect != null && !CheckTrack(station1ToConnect, station2ToConnect))
            {
                Track track = new Track(station1ToConnect, station2ToConnect, length);
                AddTrack(track);
            }
        }

        public void AddTrain(Train train)
        {
            trains.Add(train);
        }

        public void RemoveStation(string name)
        {
            Station? stationToRemove = stations.Find(station => station.Name == name);
            if (stationToRemove != null)
            {
                stations.Remove(stationToRemove);
            }
        }

        public void RemoveTrain(string id)
        {
            Train? trainToRemove = trains.Find(train => train.Id == id);
            if (trainToRemove != null)
            {
                trains.Remove(trainToRemove);
            }
        }

        public void RemoveTrackBetweenStations(string station1, string station2)
        {
            Station? station1ToRemove = stations.Find(station => station.Name == station1);
            Station? station2ToRemove = stations.Find(station => station.Name == station2);
            if (station1ToRemove != null && station2ToRemove != null)
            {
                Track? trackToRemove = tracks.Find(track => track.IsConnectedWith(station2ToRemove, station1ToRemove));
                if (trackToRemove != null)
                {
                    tracks.Remove(trackToRemove);
                }
            }   
        }

        public void RemoveTrackBetweenStations(Station station1, Station station2)
        {
            Track? trackToRemove = tracks.Find(track => track.IsConnectedWith(station1, station2));
            if (trackToRemove != null)
            {
                tracks.Remove(trackToRemove);
            }
        }

        public string GetStationInfo(string name)
        {
            Station? station = stations.Find(station => station.Name == name);
            if (station != null)
            {
                return station.ToString();
            }
            return "Station not found.";
        }

        public List<string> GetAllStationNames()
        {
            List<string> stationNames = new List<string>();
            foreach (Station station in stations)
            {
                stationNames.Add(station.Name);
            }
            return stationNames;
        }

        public string GetTrainInfo(string id)
        {
            Train? train = trains.Find(train => train.Id == id);
            if (train != null)
            {
                return train.ToString();
            }
            return "Train not found.";
        }

        public List<string> GetAllMovingTrains()
        {
            List<string> movingTrains = new List<string>();
            foreach (Train train in trains)
            {
                if (train.Running)
                {
                    movingTrains.Add(train.Id);
                }
            }
            return movingTrains;
        }

        

        public void StartSimulation()
        {
            return;
        }
    }
}