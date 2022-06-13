using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Application.Models.Responses
{
    public class CommitTransactionResponse
    {

        public class Rootobject
        {
            public Body body { get; set; }
            public Header header { get; set; }
        }

        public class Body
        {
            public string reservationNumber { get; set; }
            public string encryptedReservationNumber { get; set; }
            public string transactionId { get; set; }
        }

        public class Header
        {
            public string requestId { get; set; }
            public bool success { get; set; }
            public DateTime responseTime { get; set; }
            public Message[] messages { get; set; }
        }

        public class Message
        {
            public int id { get; set; }
            public string code { get; set; }
            public int messageType { get; set; }
            public string message { get; set; }
        }

    }
}
