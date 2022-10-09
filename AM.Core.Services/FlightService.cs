using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Core.Domain;


namespace AM.Core.Services
{
    public class FlightService : IFlightService
    {
        public IList<Flight> Flights { get; set; }

        public IList<DateTime> GetFlightDates(string destination)
        {
            return Flights.Where(f => f.Destination == destination)
                .Select(f => f.FlightDate)
                .ToList();
        }

        //Question 5
        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.Destination == filterValue)
                        {
                            Console.WriteLine(flight.MyPlane);
                        }

                    }
                    break;

                case "FlightDate":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.FlightDate == DateTime.Parse(filterValue))
                            Console.WriteLine(flight.MyPlane);

                    }
                    break;

                case "EffectiveArrival":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.EffectiveArrival == DateTime.Parse(filterValue))
                            Console.WriteLine(flight.MyPlane);

                    }
                    break;

                default:
                    Console.WriteLine("Attribut non existant, reessayez");
                    break;


            }

        }
    }
}
