using SanTsgProje.Domain.Reservations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Application.Interfaces
{
    public interface IBookingService
    {
        IEnumerable<Reservations> GetAll();
    }
}
