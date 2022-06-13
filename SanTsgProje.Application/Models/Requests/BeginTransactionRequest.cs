using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Application.Models.Requests
{
    public class BeginTransactionRequest
    {
        public List<string> offerIds { get; set; } = new List<string>();
        public string Currency { get; set; } = "EUR";
        public string Culture { get; set; } = "en-US";
    }
}
