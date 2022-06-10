using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Application.Models.Responses
{
    public class PriceSearchingResponse
    {
        public class Badge
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class BoardGroup
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Body
        {
            public string searchId { get; set; }
            public DateTime expiresOn { get; set; }
            public List<Hotel> hotels { get; set; }
            public Details details { get; set; }
        }

        public class CancellationPolicy
        {
            public DateTime dueDate { get; set; }
            public Price price { get; set; }
            public int provider { get; set; }
        }

        public class City
        {
            public string name { get; set; }
            public string countryId { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Country
        {
            public string internationalCode { get; set; }
            public string name { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
        }

        public class Description
        {
            public string text { get; set; }
        }

        public class Details
        {
            public bool enablePaging { get; set; }
        }

        public class Facility
        {
            public bool isPriced { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Geolocation
        {
            public string longitude { get; set; }
            public string latitude { get; set; }
        }

        public class GiataInfo
        {
            public string hotelId { get; set; }
            public string destinationId { get; set; }
        }

        public class Header
        {
            public string requestId { get; set; }
            public bool success { get; set; }
            public DateTime responseTime { get; set; }
            public List<Message> messages { get; set; }
        }

        public class Hotel
        {
            public Geolocation geolocation { get; set; }
            public double stars { get; set; }
            public double rating { get; set; }
            public List<Theme> themes { get; set; }
            public List<Facility> facilities { get; set; }
            public Location location { get; set; }
            public Country country { get; set; }
            public City city { get; set; }
            public GiataInfo giataInfo { get; set; }
            public List<Offer> offers { get; set; }
            public string address { get; set; }
            public List<BoardGroup> boardGroups { get; set; }
            public List<Badge> badges { get; set; }
            public HotelCategory hotelCategory { get; set; }
            public bool hasThirdPartyOwnOffer { get; set; }
            public int provider { get; set; }
            public string thumbnail { get; set; }
            public string thumbnailFull { get; set; }
            public Description description { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class HotelCategory
        {
            public string name { get; set; }
            public string id { get; set; }
            public string code { get; set; }
        }

        public class Location
        {
            public string name { get; set; }
            public string countryId { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Message
        {
            public int id { get; set; }
            public string code { get; set; }
            public int messageType { get; set; }
            public string message { get; set; }
        }

        public class Offer
        {
            public int night { get; set; }
            public bool isAvailable { get; set; }
            public int availability { get; set; }
            public List<Room> rooms { get; set; }
            public bool isRefundable { get; set; }
            public List<CancellationPolicy> cancellationPolicies { get; set; }
            public DateTime expiresOn { get; set; }
            public string offerId { get; set; }
            public DateTime checkIn { get; set; }
            public Price price { get; set; }
            public int provider { get; set; }
        }

        public class Price
        {
            public double amount { get; set; }
            public string currency { get; set; }
        }

        public class Room
        {
            public string roomId { get; set; }
            public string roomName { get; set; }
            public string boardId { get; set; }
            public string boardName { get; set; }
            public List<BoardGroup> boardGroups { get; set; }
            public int stopSaleGuaranteed { get; set; }
            public int stopSaleStandart { get; set; }
            public List<Traveller> travellers { get; set; }
        }

        public class Root
        {
            public Body body { get; set; }
            public Header header { get; set; }
        }

        public class Theme
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Traveller
        {
            public int type { get; set; }
            public int age { get; set; }
            public string nationality { get; set; }
            public int minAge { get; set; }
            public int maxAge { get; set; }
        }


    }
}
