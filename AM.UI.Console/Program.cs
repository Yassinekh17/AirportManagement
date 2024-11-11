// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
/*Plane plane1 = new Plane();
plane1.PlaneType = PlaneType.AirBus;
plane1.Capacity = 200;
plane1.ManufactureDate = new DateTime(2018, 12, 03);
Console.WriteLine(plane1.ToString());*/
/*Plane plane2 = new Plane
{
    PlaneType = PlaneType.AirBus, 
    Capacity=200,
    ManufactureDate = new DateTime(2018, 12, 03),
};
Console.WriteLine(plane2);
Passenger passenger1 = new Passenger
{
    FirstName = "Sarah",
    LastName = "Hammami",
    EmailAdress = "email",
};
Console.WriteLine(passenger1.checkProfile("Sarah", "Hammami"));
Console.WriteLine(passenger1.checkProfile("Hammami", "Sarah"));
Console.WriteLine(passenger1.checkProfile("Hammami", "Sarah", "email"));
Traveller traveller = new Traveller
{

};
passenger1.PassengerType();
traveller.PassengerType();
*/
//ServiceFlight sf= new ServiceFlight();
//sf.Flights = TestData.listFlights;
//List< DateTime > lista= new List< DateTime >();
//lista =sf.GetFlightDates("Paris");
//foreach(var ka3ba in lista)
//{
//    Console.WriteLine(ka3ba);
//}
//var DT = new DateTime(2022, 01, 01, 15, 10, 10);
//sf.getFlights("Destination", "Paris");
//Console.WriteLine("FILTER DATE:");
//sf.getFlights("FlightDate", DT.ToString());

AMContext context = new AMContext();
context.Flights.Add(TestData.flight2);
context.SaveChanges();
Console.WriteLine(context.Flights.First());
