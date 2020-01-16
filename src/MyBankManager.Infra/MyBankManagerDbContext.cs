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


            modelBuilder.Entity<Transaction>()
                   .HasOne(m => m.AccountFrom)
                   .WithMany(t => t.TransactionsAccountFrom)
                   .HasForeignKey(m => m.AccountFromId)
                   .OnDelete(DeleteBehavior.ClientNoAction)
                   .IsRequired();

            modelBuilder.Entity<Transaction>()
                   .HasOne(m => m.AccountTo)
                   .WithMany(t => t.TransactionsAccountTo)
                   .HasForeignKey(m => m.AccountToId)
                   .OnDelete(DeleteBehavior.ClientNoAction)
                   .IsRequired();


        }
    }
}
