namespace RailSimulator
{
    public enum Service
    {
        Restaurant,
        Shop,
        Toilets,
        WaitingRoom,
        TicketOffice,
        InformationDesk,
        LuggageStorage,
        CoffeeShop,
        Playground
    }
    public class MainStation : Station
    {
        private List<Service> services = new List<Service>();
        public MainStation(string name, Pair coordinates, int tracks, List<Service> services) : base(name, coordinates, tracks)
        {
            this.services = services;
        }

        public override void HandleTrainArrival(Train train)
        {
            int? assignedTrack = AssignTrackToTrain(train);

            if (assignedTrack.HasValue)
            {
                train.Track = assignedTrack; // Assign the track to the train
                TrainsAtStation.Add(train);
                return;
            }

            // If no track is available, the train is added to the waiting list
            waitingTrains.Add(train);
            waitingTrains = waitingTrains.OrderByDescending(GetTrainPriority).ThenBy(t => t.Route.GetTime(Name, true)).ToList();
        }

        // Priority: Express > Fast > Passenger > Freight
        private int GetTrainPriority(Train train)
        {
            if (train.Type == TrainType.Express) return 3;
            if (train.Type == TrainType.Fast) return 2;
            if (train.Type == TrainType.Passenger) return 1;
            return 0; // Freight trains are with lower priority
        }

        public List<Service> Services
        {
            get { return services; }
        }

        public void AddService(Service service)
        {
            services.Add(service);
        }

        public Service RemoveService(Service service)
        {
            services.Remove(service);
            return service;
        }

        public bool CheckForService(Service service)
        {
            return services.Contains(service);
        }

        public override string ToString()
        {
            return "Main station " + Name + " at " + Coordinates + " with services " + string.Join(", ", services) + ".";
        }
    }
}