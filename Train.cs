using System;

namespace RailSimulator
{
    public enum TrainType
    {
        Freight,
        Passenger,
        Fast,
        Express,
        Suburban,
    }

    public enum PassengerClass
    {
        First,
        Second,
        SleepingCar
    }

    public abstract class Train
    {
        public string Id { get; }
        public TrainType Type { get; private set; }
        public double Speed { get; protected set; }
        public int Cars { get; protected set; }
        public Route Route { get; protected set; }
        protected int? track;
        public bool Running { get; protected set; } = false;

        public Train(string trainId, TrainType trainType, double speed, int cars, Route route)
        {
            Id = trainId;
            Type = trainType;

            if (speed < 0)
            {
                throw new ArgumentException("Speed must be non-negative");
            }
            Speed = speed;

            if (cars < 0)
            {
                throw new ArgumentException("Number of cars must be non-negative");
            }
            Cars = cars;

            Route = route;
            track = null;
        }

        public string TrainId
        {
            get { return Id; }
        }

        public int? Track
        {
            get { return track; }
            set { track = value; }
        }
        
        public abstract void Move();

        public void Stop()
        {
            return;
        }

        public override string ToString()
        {
            return Type + " train " + Id + " with " + Cars + " cars.";
        }
    }

    public class PassengerTrain(string trainId, TrainType trainType, double speed, int cars, Route route, int passengerCount, Dictionary<PassengerClass, int> seatCapacity, bool hasBuffet, bool hasWifi) : Train(trainId, trainType, speed, cars, route)
    {
        private int passengerCount = passengerCount;
        private Dictionary<PassengerClass, int> seatCapacity = seatCapacity;
        public bool HasBuffet { get; } = hasBuffet;
        public bool HasWifi { get; } = hasWifi;

        public override void Move()
        {
            return;
        }

        public override string ToString()
        {
            return "Passenger train " + Id + " with " + passengerCount + " passengers.";
        }
    }

    public class FreightTrain(string trainId, TrainType trainType, double speed, int cars, Route route, double cargoWeight) : Train(trainId, trainType, speed, cars, route)
    {
        private double cargoWeight = cargoWeight;

        public override void Move()
        {
            return;
        }

        public override string ToString()
        {
            return "Freight train " + Id + " with " + cargoWeight + " tons of cargo.";
        }
    }
}