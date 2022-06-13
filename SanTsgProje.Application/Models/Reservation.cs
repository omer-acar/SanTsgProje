using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Application.Models
{
    public class Reservation
    {
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
        public string TransactionId { get; set; }
        public string ReservationNumber { get; set; }


    }
}
