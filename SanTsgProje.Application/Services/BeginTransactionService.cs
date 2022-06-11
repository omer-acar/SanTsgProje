using SanTsgProje.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SanTsgProje.Application.Services
{
    public class BeginTransactionService : IBeginTransactionService
    {
        public Task BeginTransaction()
        {
            return Task.CompletedTask;
        }
    }
}
