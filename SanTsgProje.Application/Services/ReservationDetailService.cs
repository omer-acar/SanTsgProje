using Newtonsoft.Json;
using SanTsgProje.Application.Interfaces;
using SanTsgProje.Application.Models.Requests;
using SanTsgProje.Application.Models.Responses;
using SanTsgProje.Data;
using SanTsgProje.Domain.Reservations;
using System.Threading.Tasks;

namespace SanTsgProje.Application.Services
{
    public class ReservationDetailService : IReservationDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApiService _apiService;

        public ReservationDetailService(IUnitOfWork unitOfWork, IApiService apiService)
        {
            _unitOfWork = unitOfWork;
            _apiService = apiService;
        }

        public async Task<Reservations> SaveReservation(string reservationNumber)
        {
            //Request Json Body
            Reservations reservations = null;
            ReservationDetailRequest reservationDetailRequest = new ReservationDetailRequest() { reservationNumber = reservationNumber };

            //Url for post api
            var addurl = "api/bookingservice/getreservationdetail";

            // Post to Api and Get Response
            var response = await _apiService.Post(reservationDetailRequest, addurl);

            //If response is success set to Reservation details
            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadAsStringAsync();
                ReservationDetailResponse.Rootobject deserializedJson = JsonConvert.DeserializeObject<ReservationDetailResponse.Rootobject>(id);

                var resarvationData = deserializedJson.body.reservationData;
                reservations = new Reservations
                {
                    TotalPrice = resarvationData.reservationInfo.totalPrice.amount,
                    HotelName = resarvationData.services[0].name,
                    Night = resarvationData.services[0].serviceDetails.night,
                    Room = resarvationData.services[0].serviceDetails.room,
                    BeginDate = resarvationData.services[0].beginDate,
                    EndDate = resarvationData.services[0].endDate,
                    Adult = resarvationData.services[0].adult,
                    reservationNumber = resarvationData.services[0].code,
                    TravallerName = resarvationData.travellers[0].name,
                    TravallerSurname = resarvationData.travellers[0].surname,
                    TravallerEmail = resarvationData.travellers[0].address.email
                };
                _unitOfWork.ReservationSave.Add(reservations);
                _unitOfWork.Complete();
            }
            return reservations;

        }
    }
}
