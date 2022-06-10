using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Application.Models.Requests
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
