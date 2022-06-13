using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Application.Models.Responses
{
    public class SetReservationResponse
    {

        public class Rootobject
        {
            public Body body { get; set; }
            public Header header { get; set; }
        }

        public class Body
        {
            public string transactionId { get; set; }
            public DateTime expiresOn { get; set; }
            public Reservationdata reservationData { get; set; }
            public int status { get; set; }
            public int transactionType { get; set; }
        }

        public class Reservationdata
        {
            public Traveller[] travellers { get; set; }
            public Reservationinfo reservationInfo { get; set; }
            public Service1[] services { get; set; }
            public Paymentdetail paymentDetail { get; set; }
            public object[] invoices { get; set; }
        }

        public class Reservationinfo
        {
            public string bookingNumber { get; set; }
            public Agency agency { get; set; }
            public Agencyuser agencyUser { get; set; }
            public DateTime beginDate { get; set; }
            public DateTime endDate { get; set; }
            public string note { get; set; }
            public Saleprice salePrice { get; set; }
            public Supplementdiscount supplementDiscount { get; set; }
            public Passengereb passengerEB { get; set; }
            public Agencyeb agencyEB { get; set; }
            public Passengeramounttopay passengerAmountToPay { get; set; }
            public Agencyamounttopay agencyAmountToPay { get; set; }
            public Discount discount { get; set; }
            public Agencybalance agencyBalance { get; set; }
            public Passengerbalance passengerBalance { get; set; }
            public Agencycommission agencyCommission { get; set; }
            public Brokercommission brokerCommission { get; set; }
            public Agencysupplementcommission agencySupplementCommission { get; set; }
            public Promotionamount promotionAmount { get; set; }
            public Pricetopay priceToPay { get; set; }
            public Agencypricetopay agencyPriceToPay { get; set; }
            public Passengerpricetopay passengerPriceToPay { get; set; }
            public Totalprice totalPrice { get; set; }
            public int reservationStatus { get; set; }
            public int confirmationStatus { get; set; }
            public int paymentStatus { get; set; }
            public object[] documents { get; set; }
            public object[] otherDocuments { get; set; }
            public Reservableinfo reservableInfo { get; set; }
            public int paymentFrom { get; set; }
            public Departurecountry departureCountry { get; set; }
            public Departurecity departureCity { get; set; }
            public Arrivalcountry arrivalCountry { get; set; }
            public Arrivalcity arrivalCity { get; set; }
            public DateTime createDate { get; set; }
            public Additionalfields additionalFields { get; set; }
            public string additionalCode1 { get; set; }
            public string additionalCode2 { get; set; }
            public string additionalCode3 { get; set; }
            public string additionalCode4 { get; set; }
            public float agencyDiscount { get; set; }
            public bool hasAvailablePromotionCode { get; set; }
        }

        public class Agency
        {
            public string code { get; set; }
            public string name { get; set; }
            public Country country { get; set; }
            public Address address { get; set; }
            public bool ownAgency { get; set; }
            public bool aceExport { get; set; }
        }

        public class Country
        {
            public string internationalCode { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
        }

        public class Address
        {
            public Country1 country { get; set; }
            public string[] addressLines { get; set; }
            public string zipCode { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string address { get; set; }
        }

        public class Country1
        {
            public string internationalCode { get; set; }
            public string name { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Agencyuser
        {
            public Office office { get; set; }
            public Operator _operator { get; set; }
            public Market market { get; set; }
            public Agency1 agency { get; set; }
            public string name { get; set; }
            public string code { get; set; }
        }

        public class Office
        {
            public string code { get; set; }
            public string name { get; set; }
        }

        public class Operator
        {
            public string code { get; set; }
            public string name { get; set; }
            public bool agencyCanDiscountCommission { get; set; }
        }

        public class Market
        {
            public string code { get; set; }
            public string name { get; set; }
        }

        public class Agency1
        {
            public string code { get; set; }
            public string name { get; set; }
            public bool ownAgency { get; set; }
            public bool aceExport { get; set; }
        }

        public class Saleprice
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Supplementdiscount
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Passengereb
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Agencyeb
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Passengeramounttopay
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Agencyamounttopay
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Discount
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Agencybalance
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Passengerbalance
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Agencycommission
        {
            public float percent { get; set; }
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Brokercommission
        {
            public float percent { get; set; }
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Agencysupplementcommission
        {
            public float percent { get; set; }
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Promotionamount
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Pricetopay
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Agencypricetopay
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Passengerpricetopay
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Totalprice
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Reservableinfo
        {
            public bool reservable { get; set; }
            public DateTime optionDate { get; set; }
        }

        public class Departurecountry
        {
            public string code { get; set; }
            public string internationalCode { get; set; }
            public string name { get; set; }
            public int type { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Departurecity
        {
            public string code { get; set; }
            public string name { get; set; }
            public int type { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Arrivalcountry
        {
            public string code { get; set; }
            public string internationalCode { get; set; }
            public string name { get; set; }
            public int type { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Arrivalcity
        {
            public string code { get; set; }
            public string name { get; set; }
            public int type { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Additionalfields
        {
            public string smsLimit { get; set; }
            public string priceChanged { get; set; }
            public string allowSalePriceEdit { get; set; }
            public string sendFlightSms { get; set; }
        }

        public class Paymentdetail
        {
            public Paymentplan[] paymentPlan { get; set; }
            public object[] paymentInfo { get; set; }
        }

        public class Paymentplan
        {
            public int paymentNo { get; set; }
            public DateTime dueDate { get; set; }
            public Price price { get; set; }
            public bool paymentStatus { get; set; }
        }

        public class Price
        {
            public float percent { get; set; }
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Traveller
        {
            public string travellerId { get; set; }
            public int type { get; set; }
            public int title { get; set; }
            public Availabletitle[] availableTitles { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public bool isLeader { get; set; }
            public DateTime birthDate { get; set; }
            public int age { get; set; }
            public Nationality nationality { get; set; }
            public string identityNumber { get; set; }
            public Passportinfo passportInfo { get; set; }
            public Address1 address { get; set; }
            public Destinationaddress destinationAddress { get; set; }
            public Service[] services { get; set; }
            public int gender { get; set; }
            public int orderNumber { get; set; }
            public DateTime birthDateFrom { get; set; }
            public DateTime birthDateTo { get; set; }
            public string[] requiredFields { get; set; }
            public object[] documents { get; set; }
            public int passengerType { get; set; }
            public Additionalfields1 additionalFields { get; set; }
            public object[] insertFields { get; set; }
            public int status { get; set; }
        }

        public class Nationality
        {
            public string name { get; set; }
            public string twoLetterCode { get; set; }
            public string threeLetterCode { get; set; }
            public string numericCode { get; set; }
            public string isdCode { get; set; }
        }

        public class Passportinfo
        {
            public string serial { get; set; }
            public string number { get; set; }
            public DateTime expireDate { get; set; }
            public DateTime issueDate { get; set; }
            public string citizenshipCountryCode { get; set; }
        }

        public class Address1
        {
            public Contactphone contactPhone { get; set; }
            public string email { get; set; }
            public string address { get; set; }
            public string zipCode { get; set; }
            public City city { get; set; }
            public Country2 country { get; set; }
        }

        public class Contactphone
        {
            public string countryCode { get; set; }
            public string phoneNumber { get; set; }
        }

        public class City
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Country2
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Destinationaddress
        {
        }

        public class Additionalfields1
        {
            public string travellerTypeOrder { get; set; }
            public string travellerUniqueID { get; set; }
            public string tourVisio_TravellerId { get; set; }
            public string paximum_TravellerId { get; set; }
            public DateTime birthDateFrom { get; set; }
            public DateTime birthDateTo { get; set; }
        }

        public class Availabletitle
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Service
        {
            public string id { get; set; }
            public int type { get; set; }
            public Price1 price { get; set; }
            public int passengerType { get; set; }
        }

        public class Price1
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Service1
        {
            public int orderNumber { get; set; }
            public string note { get; set; }
            public Departurecountry1 departureCountry { get; set; }
            public Departurecity1 departureCity { get; set; }
            public Arrivalcountry1 arrivalCountry { get; set; }
            public Arrivalcity1 arrivalCity { get; set; }
            public Servicedetails serviceDetails { get; set; }
            public string partnerServiceId { get; set; }
            public bool isMainService { get; set; }
            public bool isRefundable { get; set; }
            public bool bundle { get; set; }
            public Cancellationpolicy[] cancellationPolicies { get; set; }
            public object[] documents { get; set; }
            public string encryptedServiceNumber { get; set; }
            public object[] priceBreakDowns { get; set; }
            public float commission { get; set; }
            public Reservableinfo1 reservableInfo { get; set; }
            public int unit { get; set; }
            public object[] conditionalSpos { get; set; }
            public int confirmationStatus { get; set; }
            public int serviceStatus { get; set; }
            public int productType { get; set; }
            public bool createServiceTypeIfNotExists { get; set; }
            public string id { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public DateTime beginDate { get; set; }
            public DateTime endDate { get; set; }
            public int adult { get; set; }
            public int child { get; set; }
            public int infant { get; set; }
            public Netprice netPrice { get; set; }
            public Price2 price { get; set; }
            public bool includePackage { get; set; }
            public bool compulsory { get; set; }
            public bool isExtraService { get; set; }
            public string supplierCode { get; set; }
            public string supplier { get; set; }
            public int provider { get; set; }
            public string[] travellers { get; set; }
            public bool thirdPartyRecord { get; set; }
            public int recordId { get; set; }
            public Additionalfields2 additionalFields { get; set; }
        }

        public class Departurecountry1
        {
            public string code { get; set; }
            public string internationalCode { get; set; }
            public string name { get; set; }
            public int type { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Departurecity1
        {
            public string name { get; set; }
            public int type { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Arrivalcountry1
        {
            public string code { get; set; }
            public string internationalCode { get; set; }
            public string name { get; set; }
            public int type { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Arrivalcity1
        {
            public string name { get; set; }
            public int type { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Servicedetails
        {
            public string serviceId { get; set; }
            public string thumbnail { get; set; }
            public Hoteldetail hotelDetail { get; set; }
            public int night { get; set; }
            public string room { get; set; }
            public string board { get; set; }
            public string accom { get; set; }
            public string star { get; set; }
            public Geolocation1 geoLocation { get; set; }
        }

        public class Hoteldetail
        {
            public Address2 address { get; set; }
            public string phoneNumber { get; set; }
            public Transferlocation transferLocation { get; set; }
            public int stopSaleGuaranteed { get; set; }
            public int stopSaleStandart { get; set; }
            public Geolocation geolocation { get; set; }
            public int stars { get; set; }
            public Location location { get; set; }
            public Country3 country { get; set; }
            public City1 city { get; set; }
            public string thumbnail { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Address2
        {
            public string[] addressLines { get; set; }
        }

        public class Transferlocation
        {
            public string code { get; set; }
            public string name { get; set; }
            public int type { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Geolocation
        {
            public string longitude { get; set; }
            public string latitude { get; set; }
        }

        public class Location
        {
            public string code { get; set; }
            public string name { get; set; }
            public int type { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Country3
        {
            public string code { get; set; }
            public string name { get; set; }
            public int type { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class City1
        {
            public string code { get; set; }
            public string name { get; set; }
            public int type { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Geolocation1
        {
            public string longitude { get; set; }
            public string latitude { get; set; }
        }

        public class Reservableinfo1
        {
            public bool reservable { get; set; }
            public DateTime optionDate { get; set; }
        }

        public class Netprice
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Price2
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Additionalfields2
        {
            public string isRefundable { get; set; }
            public string reservableInfo { get; set; }
            public string isEditable { get; set; }
        }

        public class Cancellationpolicy
        {
            public DateTime beginDate { get; set; }
            public DateTime dueDate { get; set; }
            public Price3 price { get; set; }
            public int provider { get; set; }
        }

        public class Price3
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Header
        {
            public string requestId { get; set; }
            public bool success { get; set; }
            public DateTime responseTime { get; set; }
            public Message[] messages { get; set; }
        }

        public class Message
        {
            public int id { get; set; }
            public string code { get; set; }
            public int messageType { get; set; }
            public string message { get; set; }
        }

    }
}
