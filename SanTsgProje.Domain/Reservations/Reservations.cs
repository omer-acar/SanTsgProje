using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Domain.Reservations
{
    public class Reservations
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public string HotelName { get; set; }
        public int Night { get; set; }
        public string Room { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Adult { get; set; }
        public string TravallerName { get; set; }
        public string TravallerSurname { get; set; }
        public string TravallerEmail { get; set; }
        public string reservationNumber { get; set; }
    }
}
