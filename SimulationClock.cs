using System;

namespace RailSimulator
{
    public class SimulationClock
    {
        public DateTime currentTime { get; private set; }
        private double timeMultiplier = 1.0;

        public event Action<DateTime>? TimeChanged;

        public SimulationClock(DateTime startTime)
        {
            currentTime = startTime;
        }

        public void Tick(TimeSpan deltaTime)
        {
            currentTime = currentTime.Add(TimeSpan.FromTicks((long)(deltaTime.Ticks * timeMultiplier)));
            TimeChanged?.Invoke(currentTime);
        }

        public void SetSpeedMultiplier(double multiplier)
        {
            if (multiplier <= 0)
            {
                throw new ArgumentException("Speed multiplier must be positive.");
            }
            timeMultiplier = multiplier;
        }

        public double GetSpeedMultiplier()
        {
            return timeMultiplier;
        }
    }
}