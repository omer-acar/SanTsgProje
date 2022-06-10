using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SanTsgProje.Domain.Authentications
{
    public class TokenInfo
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTimeOffset ExpiresOn { get; set; }
        public TimeSpan RemainingTime { get; set; }
    }
}
