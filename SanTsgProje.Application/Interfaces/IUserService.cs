using SanTsgProje.Domain.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SanTsgProje.Application.Interfaces
{
    public interface IUserService
    {
        Task SendPost(User user);
        IEnumerable<User> GetAll();
        User Get(int? id);
        void Add(User user);
        void ChangeStatus(int? id);
        void Edit(User user);
        void Remove(User user);
        

    }
}
