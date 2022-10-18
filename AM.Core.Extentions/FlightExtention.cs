using AM.Core.Domain;
using System.Runtime.CompilerServices;

namespace AM.Core.Extentions
{
    public static class FlightExtention
    {
        public static double GetDelay (this Flight flight)
        {
            return flight.EffectiveArrival
                .Subtract(flight.FlightDate)
                .TotalMinutes - flight.EstimatedDuration;
        }
    }
}