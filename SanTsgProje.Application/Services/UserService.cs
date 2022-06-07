using SanTsgProje.Application.Interfaces;
using SanTsgProje.Application.Models;
using SanTsgProje.Data;
using SanTsgProje.Domain.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SanTsgProje.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IEmailService _emailService;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IEmailService emailService, IUnitOfWork unitOfWork)
        {

            _emailService = emailService;
            _unitOfWork = unitOfWork;
        }
        #region Crud With Unit Of Work
        //User Add
        public void Add(User user)
        {
            _unitOfWork.User.Add(user);
            _unitOfWork.Complete();
        }

        //User ChangeStatus
        public void ChangeStatus(int? id)
        {
            var userStatus = _unitOfWork.User.Get(id);
            if (userStatus.IsActive == true)
            {
                userStatus.IsActive = false;
            }
            else if (userStatus.IsActive == false)
            {
                userStatus.IsActive = true;
            }
            _unitOfWork.Complete();
        }
        //User Edit
        public void Edit(User user)
        {
            _unitOfWork.User.Update(user);
            _unitOfWork.Complete();
        }

        //User Get
        public User Get(int? id)
        {
            return _unitOfWork.User.Get(id);
        }

        //User Get All
        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.User.GetAll();
        }

        //User Delete
        public void Remove(User user)
        {
            _unitOfWork.User.Remove(user);
            _unitOfWork.Complete();
        }
        #endregion

        //Send Post
        public async Task SendPost(User user)
        {
            MailRequest mail = new MailRequest()
            {
                Body = $"{user.UserName} Adlı kullanıcı kaydı başarıyla alınmıştır.",
                Subject = "SanTsgProje Kayit Onayi",
                ToEmail = user.Email
            };
            await _emailService.SendEmailAsync(mail);
        }

    }

}
