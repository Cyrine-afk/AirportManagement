// See https://aka.ms/new-console-template for more information


using AM.Core.Domain;
using AM.Core.Services;
using System.ComponentModel.DataAnnotations;
using static AM.Core.Services.IFlightService;

//Plane p1 = new Plane();
//p1.Capacity = 200;
//p1.ManifactureDate = new DateTime(2000,1,1);
//p1.MyPlaneType = PlaneType.Boing;

//Plane p2 = new Plane(PlaneType.AirBus, 500, new DateTime(2000, 1, 1));

//Plane p3 = new Plane() { 
//    Capacity = 200,
//    ManifactureDate=new DateTime(2000, 1, 1),
//    MyPlaneType = PlaneType.AirBus
//};

//Testing question 12
//passenger
//DateTime bday = new DateTime(2000, 5, 25);
//String passportN = "ABC06283";
//String EmailAdd = "cyrine.tr@gmail.com";
//String firstName = "Cyrine";
//String lastName = "Trabelsi";
//String telNumber = "25147623";
//Passenger pas1 = new Passenger(bday, passportN, EmailAdd, firstName, lastName, telNumber, new List<Flight>());


//Console.WriteLine(pas1.GetPassengerType());

////traveller
//Passenger pas2 = new Traveller();
//pas2.BirthDate = new DateTime(2000, 5, 25);
//pas2.EmailAddress = "cyrine.tr@gmail.com";
//pas2.FirstName = "Cyrine";
//pas2.LastName = "Trabelsi";
//pas2.Flights = new List<Flight>();
//pas2.PassportNumber = "ABC06283";
//pas2.TelNumber = "25147623";

//Console.WriteLine(pas2.GetPassengerType());

//staff
//Passenger pas3 = new Staff();
//pas3.BirthDate = new DateTime(2000, 1, 1);
//pas3.EmailAddress = "cyrine.tr@gmail.com";
//pas3.FirstName = "Cyrine";
//pas3.LastName = "Trabelsi";
//pas3.Flights = new List<Flight>();
//pas3.PassportNumber = "ABC06283";
//pas3.TelNumber = "25147623";

//Console.WriteLine(pas3.GetPassengerType());

//Testing question 13
//Passenger pass = new Passenger();
//int age = 0;
//pass.GetAge(new DateTime(2000, 1, 1), ref age);
//pass.GetAge(pas3);

//Console.WriteLine("1st meth:" + age + " ans");
//Console.WriteLine("2nd meth:" + pas3.Age + " ans");

////Testing question 14
//Console.WriteLine("L'âge est: " + pas3.Age + " ans");

GetScore meth1 = delegate(Passenger p)
{
    return p.Flights.Count();
};
GetScore meth2 = delegate(Passenger p)
{
    return p.Flights.Where(f => f.Destination == "Tunisie" || f.Departure == "Tunisie")
    .Count();
}; 

IFlightService flightService = new FlightService();
Passenger passengerSenior = flightService.GetSeniorPassenger(meth1);

