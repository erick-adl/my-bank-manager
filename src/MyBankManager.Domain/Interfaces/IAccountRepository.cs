using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBankManager.Domain.Entities;

namespace MyBankManager.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetById(Guid id);
        Task<IEnumerable<Account>> Get();
        Task Add(Account account);
        void Delete(Account account);
    }
}
