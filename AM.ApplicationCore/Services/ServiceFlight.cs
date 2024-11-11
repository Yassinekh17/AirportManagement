using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var query1 = from flight in Flights
                         group flight by flight.Destination;
            var query2 = Flights.GroupBy(f => f.Destination);
            foreach(var grouped in query1)
            {
                Console.WriteLine("Destination: "+ grouped.Key );
                foreach(var f in grouped)
                {
                    Console.WriteLine("Decolage: " + f.FlightDate);
                }
            }
            return query1;
        }

        public double DurationAverage(string destination)
        {
            var query1= (from f in Flights
                        where f.Destination == destination
                        select f.EstimatedDuration).Average();
            var query2= Flights.Where(f => f.Destination == destination).Select(f=> f.EstimatedDuration).Average();
            return query1;
        }

        public List<DateTime> GetFlightDates(string destination)
        {   // Ecriture simple
            var query1= from flight in Flights
                        where flight.Destination == destination
                        select flight.FlightDate;
            // Ecriture lambda
            var query2 = Flights.Where(f=> f.Destination == destination).Select(f => f.FlightDate);
            return query1.ToList();

        }

        /*public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> flightsL = new List<DateTime>();
            foreach (var flight in Flights)
            {
                if (flight.Destination == destination)
                    flightsL.Add(flight.FlightDate);

            }
            return flightsL;
        }*/

        /*public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> flightsL = new List<DateTime>();
            for (int i=0; i<Flights.Count; i++)
            {
                if (Flights[i].Destination == destination)
                {
                    flightsL.Add(Flights[i].FlightDate);
                }
            }
            return flightsL;
        }*/
        public void getFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.Destination == filterValue)
                                Console.WriteLine(flight);

                        }
                    };
                    break;
                case "FlightDate":
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.FlightDate == DateTime.Parse(filterValue))
                                Console.WriteLine(flight);

                        }
                    }
                    break;
                case "EffectiveArrival":
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.EffectiveArrival == DateTime.Parse(filterValue))
                                Console.WriteLine(flight);

                        }
                    }
                    break;
                    default:
                    Console.WriteLine("Invalid Filter Type");
                    break;
            }

        }

        public List<Flight> OrderedDurationFlights()
        {
            var query1= from flight in Flights
                        orderby flight.EstimatedDuration descending
                        select flight;
            var query2= Flights.OrderByDescending(f => f.EstimatedDuration);
            return query1.ToList();

        }

        public int programmedFlightNumber(DateTime startDate)
        {
            var query1 = (from flight in Flights
                          where DateTime.Compare(flight.FlightDate, startDate) > 0 &&
                          (flight.FlightDate - startDate).TotalDays <= 7
                          select flight ).Count(); 
                        
            var query2= Flights.Where(flight=> DateTime.Compare(flight.FlightDate, startDate) > 0 &&
                          (flight.FlightDate - startDate).TotalDays <= 7)
                          .Count();
            return query1; 
        }

        public List<Traveller> SeniorTravellers(Flight flight)
        {
            var query1 = (from p in flight.Passengers.OfType<Traveller>()
                         orderby p.BirthDate
                         select p).Take(3);
            var query2 = flight.Passengers.OfType<Traveller>().OrderBy(p=>p.BirthDate).Take(3);
            return query1.ToList();
        }

        public void showFlightDetails(Plane plane)
        {
            var query1 = from flight in Flights
                         where flight.plane == plane
                         select new
                         {
                             flight.Destination,
                             flight.FlightDate
                         }; 
            var query2 = Flights.Where(f=>f.plane == plane)
                .Select(f => new {
                    f.Destination, f.FlightDate });
            foreach (var f in query1)
            {
                Console.WriteLine("Destination: "+f.Destination+ "Flight date: "+ f.FlightDate);   
            }
        }
    }
}