using System;
using Microsoft.EntityFrameworkCore;
using MyBankManager.Domain.Entities;
using MyBankManager.Infra.EntityConfig;

namespace MyBankManager.Infra
{
    public class MyBankManagerDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public MyBankManagerDbContext(DbContextOptions<MyBankManagerDbContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfig());
            modelBuilder.ApplyConfiguration(new TransactionConfig());
            
        }
    }
}
