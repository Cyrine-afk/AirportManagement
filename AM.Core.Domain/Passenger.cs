using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public string PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelNumber { get; set; }
        public int Id { get; set; }

        //Question 14
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - BirthDate.Year;

                if (DateTime.Now.Month < BirthDate.Month)
                    age--;

                if ((DateTime.Now.Month == BirthDate.Month) && (DateTime.Now.Day < BirthDate.Day))
                    age--;
                return age;
            }
        }
        public ICollection<Flight> Flights { get; set; }

        public Passenger()
        {

        }

        public Passenger(DateTime birthDate, string passportNumber, string emailAddress, string firstName, string lastName, string telNumber, ICollection<Flight> flights)
        {
            BirthDate = birthDate;
            PassportNumber = passportNumber;
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
            TelNumber = telNumber;
            Flights = flights;
        }



        //public bool CheckProfile (string firstname, string lastname)
        //{
        //    return FirstName == firstname 
        //        && LastName == lastname;
        //}
        //public bool CheckProfile (string firstname, string lastname, string emailaddress)
        //{
        //    return FirstName == firstname 
        //        && LastName == lastname 
        //        && EmailAddress == emailaddress;
        //}
        public bool CheckProfile(string firstname, 
            string lastname, 
            string emailaddress=null)
        {
            //if (emailaddress == null)
            //    return FirstName == firstname
            //    && LastName == lastname;
            //else
            //    return FirstName == firstname
            //    && LastName == lastname
            //    && EmailAddress == emailaddress;

            return FirstName == firstname
                && LastName == lastname
                && (emailaddress == null || EmailAddress == emailaddress);
        }

        //Question 12
        public virtual string GetPassengerType()
        {
                return "I am a passenger";
        }

        //Question 13
        public void GetAge(DateTime birthDate, ref int calculatedAge)
        {
            //calcul de l'âge théorique sans prendre en considération le mois et le jour
            calculatedAge = DateTime.Now.Year - birthDate.Year;
            //calcul de lâge en prenant en considération le mois de naissance 
            if (DateTime.Now.Month < birthDate.Month)
                calculatedAge--;
            //calcul de lâge en prenant en considération le mois ET LE JOUR de naissance 
            if ((DateTime.Now.Month == birthDate.Month) && (DateTime.Now.Day < birthDate.Day))
                calculatedAge--;
        }
        //public void GetAge(Passenger aPassenger)
        //{
        //    aPassenger.Age = DateTime.Now.Year - aPassenger.BirthDate.Year;
        //    if (DateTime.Now.Month < aPassenger.BirthDate.Month)
        //        aPassenger.Age--;
        //    if ((DateTime.Now.Month == aPassenger.BirthDate.Month) && (DateTime.Now.Day < aPassenger.BirthDate.Day))
        //        aPassenger.Age--;
        //}

        public override string ToString()
        {
            return "BirthDate:"+BirthDate+
                ", PassportNumber: "+ PassportNumber+
                ", EmailAddress: "+ EmailAddress+
                ", FirstName: "+ FirstName+
                ", LastName: "+ LastName+
                ", TelNumber: "+ TelNumber;
        }
    }
}
