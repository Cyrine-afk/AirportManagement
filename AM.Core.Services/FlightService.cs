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

        //Question 4 + 6
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

                case "Departure":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.Departure == filterValue)
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

                case "EstimatedDuration":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.EstimatedDuration == int.Parse(filterValue))
                            Console.WriteLine(flight.MyPlane);

                    }
                    break;

                default:
                    Console.WriteLine("Attribut non-existant, réessayez");
                    break;


            }

        }

        //Question 7
        public void ShowFlightDetails(Plane myplane)
        {
            Flights.Where(f => f.MyPlane == myplane)
                .Select(f => f.Destination + f.FlightDate);
        }

        //Question 8
        public int GetWeeklyFlightNumber(DateTime dateflight)
        {
            return Flights.Where(f => f.FlightDate >= dateflight && (f.FlightDate - dateflight).TotalDays <= 7)
                .Count();
        }

        //Question 9
        public double GetDurationAverage(string destination)
        {
            return Flights.Where(f => f.Destination == destination)
                .Average(f => f.EstimatedDuration);
        }

        //Question 10
        public IList<Flight> SortFlights()
        {
            return Flights.OrderByDescending(f => f.EstimatedDuration)
                .ToList();
        }

        //Question 11
        public IList<Passenger> GetThreeOlderTravellers(Flight flight)
        {
            return flight.Passengers.OfType<Traveller>()
                .OrderByDescending(p => p.Age)
                .Take(3)
                .ToList<Passenger>();
        }

        //Question 12
        public void ShowGroupedFlights()
        {
            var result = from f in Flights
                         group f by f.Destination; //Destination is the key
            foreach(var group in result)
            {
                Console.WriteLine(group.Key);
                foreach(var f in group) //group est la propriété qui permet de retourner les listes
                {
                    Console.WriteLine(f);
                }
            }
        }

        public Passenger GetSeniorPassenger(IFlightService.GetScore methode)
        {
            return (from f in Flights
                   from p in f.Passengers
                   orderby methode(p) descending
                   select p).First();
        }
    }
}
