using Microsoft.AspNetCore.Mvc;
using SanTsgProje.Application.Interfaces;
using SanTsgProje.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SanTsgProje.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBeginTransactionService _beginTransactionservice;
        private readonly ISetReservationService _setReservationService;
        private readonly ICommitTransactionService _commitTransactionService;
        private readonly IReservationDetailService _reservationDetailService;
        private readonly IBookingService _bookingService;

        public BookingController(IBeginTransactionService beginTransactionservice, ISetReservationService setReservationService, ICommitTransactionService commitTransactionService, IReservationDetailService reservationDetailService, IBookingService bookingService)
        {
            _beginTransactionservice = beginTransactionservice;
            _setReservationService = setReservationService;
            _commitTransactionService = commitTransactionService;
            _reservationDetailService = reservationDetailService;
            _bookingService = bookingService;
        }

        public IActionResult Index() // View All Reservations 
        {
            
            return View(_bookingService.GetAll());
        }

        public async Task<IActionResult> Booking(string FirstName , string LastName , string Email , string OfferId) //Booking procces
        {
            // Begin Transaction ,It takes Offer id and returns us Transaction Id
            var transactionId = await _beginTransactionservice.BeginTransaction(OfferId);
            // Set Reservation ,Retrieving reservation information
            var setReservation = await _setReservationService.SetReservation(FirstName,LastName,Email,transactionId);
            // Show Reservation information
            return View(setReservation);
        }
        public async Task<IActionResult> CompleteReservation(string TransactionId)
        {
            // Commit Transaction , It saves the reservation information.
            var reservationNumber = await _commitTransactionService.CompleteReservation(TransactionId);
            // Reservation Detail , It saves the reservation information to the database.
            var details = await _reservationDetailService.SaveReservation(reservationNumber);
            return View(details);
        }
    }

}
