using SanTsgProje.Domain.Authentications;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Data.Repositories.Interfaces
{
    public interface IAuthenticationRepository : IRepository<TokenInfo>
    {
        public TokenInfo GetById();

    }
}
