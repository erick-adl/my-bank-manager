using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBankManager.Domain.Entities;
using MyBankManager.Domain.Interfaces;

namespace MyBankManager.Infra.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MyBankManagerDbContext _context;
        public TransactionRepository(MyBankManagerDbContext TransactionDbContext) => _context = TransactionDbContext;

        public void Delete(Transaction Transaction) => _context.Remove(Transaction);

        public async Task<IEnumerable<Transaction>> Get() => await _context.Transactions.ToListAsync();

        public async Task<Transaction> GetById(Guid id) =>
            await _context.Transactions.FirstOrDefaultAsync(p => p.TransactionId == id);

        public async Task Add(Transaction Transaction) => await _context.AddAsync(Transaction);


    }
}