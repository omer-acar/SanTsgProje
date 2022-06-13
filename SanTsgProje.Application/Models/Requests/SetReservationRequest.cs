using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Application.Models.Requests
{
    public class SetReservationRequest
    {

        public class Rootobject
        {
            public string transactionId { get; set; }
            public Traveller[] travellers { get; set; }
        }

        public class Traveller
        {
            public string travellerId { get; set; } = "1";
            public int type { get; set; } = 1;
            public int title { get; set; }=1;
            public int passengerType { get; set; }=1;
            public string name { get; set; }
            public string surname { get; set; }
            public bool isLeader { get; set; } = true;
            public DateTime birthDate { get; set; } = DateTime.Now;
            public Nationality nationality { get; set; } = new Nationality { twoLetterCode = "DE" };
            public string identityNumber { get; set; } = "";
            public Passportinfo passportInfo { get; set; }=new Passportinfo 
            { serial="a",
              number="13",
              expireDate = DateTime.MaxValue,
              issueDate= DateTime.MinValue,
              citizenshipCountryCode=""

            };


            public Address address { get; set; } = new Address
            {
                address = "",
                zipCode ="",
                
                contactPhone= new Contactphone
                {
                    countryCode="90",
                    areaCode="555",
                    phoneNumber= "5555555"
                },
                city=new City
                {
                    id="",
                    name=""
                }
            };
            public Destinationaddress destinationAddress { get; set; } = new Destinationaddress
            {

            };
            public int orderNumber { get; set; } = 1;
            public object[] documents { get; set; } = new object[] 
            { 

            };
            public object[] insertFields { get; set; } = new object[]
            {

            };
            public int status { get; set; } = 0;
        }

        public class Nationality
        {
            public string twoLetterCode { get; set; }
        }

        public class Passportinfo
        {
            public string serial { get; set; }
            public string number { get; set; }
            public DateTime expireDate { get; set; }
            public DateTime issueDate { get; set; }
            public string citizenshipCountryCode { get; set; }
        }

        public class Address
        {
            public Contactphone contactPhone { get; set; }
            public string email { get; set; }
            public string address { get; set; }
            public string zipCode { get; set; }
            public City city { get; set; }
            public Country country { get; set; }
        }

        public class Contactphone
        {
            public string countryCode { get; set; }
            public string areaCode { get; set; }
            public string phoneNumber { get; set; }
        }

        public class City
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Country
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Destinationaddress
        {
        }

    }
}
