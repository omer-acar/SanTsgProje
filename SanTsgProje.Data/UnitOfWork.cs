using SanTsgProje.Data.Repositories;
using SanTsgProje.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Data
{
    public interface IUnitOfWork
    {
        public IUserRepository User { get; }
        public IAuthenticationRepository Authentication { get; }
        public IReservationSaveRepository ReservationSave { get; }
        void Complete();
        void Dispose();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjeDbContext _context;

        public IUserRepository User { get; private set; }
        public IAuthenticationRepository Authentication { get; private set; }
        public IReservationSaveRepository ReservationSave { get; private set; }



        public UnitOfWork(ProjeDbContext context)
        {
            _context = context;

            User = new UserRepository(context);
            Authentication = new AuthenticationRepository(context);
            ReservationSave = new ReservationSaveRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
    
