using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Application.Models
{
    public class ProductInfo
    {
        public string HotelName { get; set; }
        public string Description { get; set; }
        public string HotelPic { get; set; }
        public double HotelRate { get; set; }
        public string HotelWeb { get; set; }
        public string HotelPhone { get; set; }
        public string OfferId { get; set; }
        public List<string> HotelFacility { get; set; } = new List<string>();

    }
}
