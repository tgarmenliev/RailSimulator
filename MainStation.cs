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
        public MainStation(string name, Pair coordinates, List<bool> tracks, List<Service> services) : base(name, coordinates, tracks)
        {
            this.services = services;
        }

        // TODO
        public override void HandleTrainArrival(Train train)
        {
            throw new System.NotImplementedException();
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