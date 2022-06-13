using Newtonsoft.Json;
using SanTsgProje.Application.Interfaces;
using SanTsgProje.Application.Models.Requests;
using SanTsgProje.Application.Models.Responses;
using SanTsgProje.Data;
using SanTsgProje.Domain.Reservations;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SanTsgProje.Application.Services
{
    public class ReservationDetailService : IReservationDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Reservations> SaveReservation(string reservationNumber)
        {
            Reservations reservations = new Reservations();

            //Token for header from database
            var tokentype = _unitOfWork.Authentication.GetById();
            var token = tokentype.Token;

            //Url for post api
            var url = "http://service.stage.paximum.com/v2/api/bookingservice/getreservationdetail";
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            //Post with httpclient
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ReservationDetailRequest reservationDetailRequest = new ReservationDetailRequest() { reservationNumber = reservationNumber };
            var response = await httpClient.PostAsJsonAsync(url, reservationDetailRequest);
            //If response is success set to Reservation details
            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadAsStringAsync();
                ReservationDetailResponse.Rootobject deserializedJson = JsonConvert.DeserializeObject<ReservationDetailResponse.Rootobject>(id);
                reservations.reservationNumber= deserializedJson.body.reservationNumber;
                reservations.TotalPrice = deserializedJson.body.reservationData.reservationInfo.totalPrice.amount;
                reservations.HotelName = deserializedJson.body.reservationData.services[0].name;
                reservations.Night = deserializedJson.body.reservationData.services[0].serviceDetails.night;
                reservations.Room = deserializedJson.body.reservationData.services[0].serviceDetails.room;
                reservations.BeginDate = deserializedJson.body.reservationData.services[0].beginDate;
                reservations.EndDate = deserializedJson.body.reservationData.services[0].endDate;
                reservations.Adult= deserializedJson.body.reservationData.services[0].adult;
                reservations.reservationNumber= deserializedJson.body.reservationData.services[0].code;
                reservations.TravallerName = deserializedJson.body.reservationData.travellers[0].name;
                reservations.TravallerSurname = deserializedJson.body.reservationData.travellers[0].surname;
                reservations.TravallerEmail = deserializedJson.body.reservationData.travellers[0].address.email;
                _unitOfWork.ReservationSave.Add(reservations);
                _unitOfWork.Complete();
            }
            return reservations;

        }
    }
}
