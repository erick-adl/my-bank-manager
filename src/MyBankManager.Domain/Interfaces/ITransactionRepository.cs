using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBankManager.Domain.Entities;

namespace MyBankManager.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetById(Guid id);
        Task<IEnumerable<Transaction>> GetByAccountId(Guid id);
        Task<IEnumerable<Transaction>> Get();
        Task Add(Transaction account);
        void Delete(Transaction account);
    }
}
