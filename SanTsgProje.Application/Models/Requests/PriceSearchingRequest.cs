using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Application.Models.Requests
{
    public class PriceSearchingRequest
    {
        public class ArrivalLocation
        {
            public string id { get; set; }
            public int type { get; set; } = 2;
        }

        public class RoomCriterion
        {
            public int adult { get; set; } = 1;
            //public List<int> childAges { get; set; } = new List<int>() { 2/*, 13*/ };

        }

        public class Root
        {
            public bool checkAllotment { get; set; } = true;
            public bool checkStopSale { get; set; } = true;
            public bool getOnlyDiscountedPrice { get; set; } = false;
            public bool getOnlyBestOffers { get; set; } = true;
            public int productType { get; set; } = 2;
            public List<ArrivalLocation> arrivalLocations { get; set; } = new List<ArrivalLocation>
            {
                new ArrivalLocation(),
            };
            public List<RoomCriterion> roomCriteria { get; set; } = new List<RoomCriterion>()
            {       
                new RoomCriterion()

                //new RoomCriterion() {
                //    adult=1,
                //    childAges=new List<int>(){3
                //    }
                //}
            };
            public string nationality { get; set; } = "DE";
            public string checkIn { get; set; } = "2023-06-20";
            public int night { get; set; } = 1;
            public string currency { get; set; } = "EUR";
            public string culture { get; set; } = "en-US";
        }
    }
}
