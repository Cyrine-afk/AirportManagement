using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Reservation
    {
        public double Price { get; set; }
        public String Seat { get; set; }
        public bool VIP { get; set; }
    }
}
