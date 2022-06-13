using SanTsgProje.Application.Interfaces;
using SanTsgProje.Data;
using SanTsgProje.Domain.Reservations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Reservations> GetAll()
        {
            // Return All Reservations
            return _unitOfWork.ReservationSave.GetAll();
        }
    }
}
