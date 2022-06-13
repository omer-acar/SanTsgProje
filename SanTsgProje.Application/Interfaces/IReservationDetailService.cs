using SanTsgProje.Domain.Reservations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SanTsgProje.Application.Interfaces
{
    public interface IReservationDetailService
    {
        Task<Reservations> SaveReservation(string reservationNumber);
    }
}
