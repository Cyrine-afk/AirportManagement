// See https://aka.ms/new-console-template for more information


using AM.Core.Domain;
using AM.Core.Services;
using AM.Core.Extentions;
using System.ComponentModel.DataAnnotations;
using static AM.Core.Services.IFlightService;
using AM.Core.Extentions;
using AM.Data;

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

//GetScore meth1 = delegate(Passenger p)
//{
//    return p.Flights.Count();
//};
//GetScore meth2 = delegate(Passenger p)
//{
//    return p.Flights.Where(f => f.Destination == "Tunisie" || f.Departure == "Tunisie")
//    .Count();
//}; 

//IFlightService flightService = new FlightService();
//Passenger passengerSenior = flightService.GetSeniorPassenger(meth1);

Flight flight = new Flight()
{
    FlightDate = new DateTime(2022, 10, 18, 7, 0, 0),
    EstimatedDuration = 120,
    EffectiveArrival = new DateTime(2022, 10, 18, 9, 20, 0),
    Comments = "Comment"
};
//Console.WriteLine(flight.GetDelay());

Plane plane = new Plane();

AMContext context = new AMContext();
context.Planes.Add(plane);
//context.Flights.Add(flight);
context.SaveChanges();

Passenger passenger = new Passenger()
{
    BirthDate = new DateTime(2000, 1, 1),
    PassportNumber = "1234567",
    EmailAddress = "passenger@gmail.com",
    MyFullName = new FullName()
    {
        FirstName = "Passenger",
        LastName = "Passenger TN"
    },
    TelNumber = "96069516"
};

Traveller traveller = new Traveller()
{
    BirthDate = new DateTime(2000, 1, 1),
    PassportNumber = "1234566",
    EmailAddress = "traveller@gmail.com",
    MyFullName = new FullName()
    {
        FirstName = "Traveller",
        LastName = "Traveller TN"
    },
    TelNumber = "96069516",
    HealthInformation = "",
    Nationality = "Tunisian"
};

Staff staff = new Staff()
{
    BirthDate = new DateTime(2000, 1, 1),
    PassportNumber = "1234565",
    EmailAddress = "staff@gmail.com",
    MyFullName = new FullName()
    {
        FirstName = "Staff",
        LastName = "Staff TN"
    },
    TelNumber = "96069516",
    Salary = 10.2,
    Function = "Captain"
};

AMContext context2 = new AMContext();
context2.Passengers.Add(passenger);
context2.Passengers.Add(staff);
context2.Passengers.Add(traveller);
context2.SaveChanges();
