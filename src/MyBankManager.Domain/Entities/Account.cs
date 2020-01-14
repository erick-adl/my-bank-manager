using System;
using System.Collections;
using System.Collections.Generic;
using MyBankManager.Domain.ValueObjects;

namespace MyBankManager.Domain.Entities
{
    public class Account
    {
        protected Account()
        {
            this.Transactions = new List<Transaction>();
        }

        public Account(Guid accountId,  User user, double balance = 0)
        {
            this.AccountId = accountId;
            this.Balance = balance;
            this.User = user;
            this.Transactions = new List<Transaction>();

        }
        public Guid AccountId { get; set; }
        public double Balance { get; set; }
        public User User { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

    }
}
