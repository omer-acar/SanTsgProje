using SanTsgProje.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SanTsgProje.Application.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(User user);
    }
}
