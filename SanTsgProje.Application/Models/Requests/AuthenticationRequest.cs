using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Application.Models.Requests
{
    public class AuthenticationRequest
    {
        public string Agency { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

    }
}
