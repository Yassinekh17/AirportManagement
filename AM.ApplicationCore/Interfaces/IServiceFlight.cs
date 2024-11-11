using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight
    {
        public List<DateTime> GetFlightDates(string destination);
        public void getFlights(string filterType, string filterValue);
        public void showFlightDetails (Plane plane);
        int programmedFlightNumber(DateTime startDate);
        double DurationAverage(String destination);
        List<Flight> OrderedDurationFlights();
        List<Traveller> SeniorTravellers(Flight flight);
        IEnumerable<IGrouping<string,Flight>> DestinationGroupedFlights(); 
    }
}
