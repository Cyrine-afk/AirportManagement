using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public interface IFlightService
    {

        delegate int GetScore(Passenger passenger);

        /// <summary>
        /// retourne la liste des dates de vols pour une destination donnée
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        IList<DateTime> GetFlightDates(String destination);

        IList<Flight> SortFlights();

        IList<Passenger> GetThreeOlderTravellers(Flight flight);

        void ShowGroupedFlights();

        Passenger GetSeniorPassenger(GetScore methode);
    }
}
