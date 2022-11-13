using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Reservation
    {
        //Clé primaire
        [Key]
        public int FlightId { get; set; }

        //Clés étrangères
        public String PassengerId { get; set; }
        public Passenger MyPassenger { get; set; }
        public Flight MyFlight { get; set; }

        //Attributs
        public double Price { get; set; }
        public String Seat { get; set; }
        public bool VIP { get; set; }
    }
}
