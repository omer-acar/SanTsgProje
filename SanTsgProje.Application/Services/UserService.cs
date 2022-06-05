using SanTsgProje.Application.Interfaces;
using SanTsgProje.Application.Models;
using SanTsgProje.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SanTsgProje.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IEmailService _emailService;

        public UserService(IEmailService emailService)
        {

            _emailService = emailService;

        }

        public async Task CreateUser(User user)
        {
            MailRequest mail = new MailRequest()
            {
                Body = "Kaydiniz basariyla alinmistir",
                Subject = "SanTsgProje Kayit Onayi",
                ToEmail = user.Email
            };
            await _emailService.SendEmailAsync(mail);
        }
    }
            
}
