using SanTsgProje.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SanTsgProje.Application.Interfaces
{
    public interface ICommitTransactionService
    {
        Task<string> CompleteReservation(string TransactionId);
    }
}
