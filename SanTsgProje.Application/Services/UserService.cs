using Microsoft.Extensions.Logging;
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
        private readonly ILogger<UserService> _logger;
        public UserService(IEmailService emailService, IUnitOfWork unitOfWork, ILogger<UserService> logger)
        {

            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        #region Crud With Unit Of Work
        //User Add
        public void Add(User user)
        {
            _unitOfWork.User.Add(user);
            _unitOfWork.Complete();
            _logger.LogInformation("Yeni kullanici eklendi.", user);
        }

        //User ChangeStatus
        public void ChangeStatus(int? id)
        {
            var user = _unitOfWork.User.Get(id);
            if (user.IsActive == true)
            {
                user.IsActive = false;
                _logger.LogInformation($"{user.UserName} adli kullanicinin statusu pasif durumuna getirildi.", user);
            }
            else if (user.IsActive == false)
            {
                user.IsActive = true;
                _logger.LogInformation($"{user.UserName} adli kullanicinin statusu aktif durumuna getirildi.", user);
            }
            _unitOfWork.Complete();
        }
        //User Edit
        public void Edit(User user)
        {
            _unitOfWork.User.Update(user);
            _unitOfWork.Complete();
            _logger.LogInformation($"{user.UserName} adli kullanicinin bilgileri degistirildi.", user);
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
            _logger.LogInformation($"{user.UserName} adli kullanici silindi.", user);
        }
        #endregion
        #region Send Post
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
            _logger.LogInformation($"{user.UserName} adli kullaniciya posta gonderildi.", user);
        }
        #endregion


    } //Basic Crud opsions

}
