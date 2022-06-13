using SanTsgProje.Data.Repositories.Interfaces;
using SanTsgProje.Domain.Reservations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Data.Repositories
{
    public class ReservationSaveRepository : Repository<Reservations>, IReservationSaveRepository
    {
        public ReservationSaveRepository(ProjeDbContext context) : base(context)
        {
        }
    }
}
