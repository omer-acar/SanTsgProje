using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Domain.Users
{
    public class User
    {
       
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }
        public string Email { get; set; }
        public DateTime DateOfSign { get; set; }=DateTime.Now.Date;
        public Boolean IsActive { get; set; }= true;

    }
}
