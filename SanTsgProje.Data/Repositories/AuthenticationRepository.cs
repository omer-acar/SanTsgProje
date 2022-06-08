using SanTsgProje.Data.Repositories.Interfaces;
using SanTsgProje.Domain.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanTsgProje.Data.Repositories
{
    public class AuthenticationRepository : Repository<TokenInfo>, IAuthenticationRepository
    {
        public AuthenticationRepository(ProjeDbContext context) : base(context)
        {
        }

        public TokenInfo GetById()  //Selected Last Token for check token expires
        {
            return _context.TokenInfos.OrderByDescending(x => x.Id).FirstOrDefault();
        }
    }
}
