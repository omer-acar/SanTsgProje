using SanTsgProje.Data.Repositories.Interfaces;
using SanTsgProje.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanTsgProje.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ProjeDbContext context) : base(context)
        {

        }

    }
} 
