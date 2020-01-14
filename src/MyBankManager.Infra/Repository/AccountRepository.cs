using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBankManager.Domain.Entities;
using MyBankManager.Domain.Interfaces;

namespace MyBankManager.Infra.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyBankManagerDbContext _context;
        public AccountRepository(MyBankManagerDbContext AccountDbContext) => _context = AccountDbContext;

        public void Delete(Account Account) => _context.Remove(Account);

        public async Task<IEnumerable<Account>> Get() => await _context.Accounts.ToListAsync();

        public async Task<Account> GetById(Guid id) =>
            await _context.Accounts.FirstOrDefaultAsync(p => p.AccountId == id);

        public async Task Add(Account Account) => await _context.AddAsync(Account);


    }
}