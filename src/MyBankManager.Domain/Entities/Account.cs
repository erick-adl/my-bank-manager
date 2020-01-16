using System;
using System.Collections;
using System.Collections.Generic;
using MyBankManager.Domain.ValueObjects;
using MyBankManager.Domain.ValueObjects.Enums;

namespace MyBankManager.Domain.Entities
{
    public class Account
    {
        protected Account()
        {
        }

        public Account(Guid accountId, Client user, double balance = 0)
        {
            this.AccountId = accountId;
            this.Balance = balance;
            this.Client = user;

        }
        public Guid AccountId { get; set; }
        public double Balance { get; set; }
        public Client Client { get; set; }
        public virtual ICollection<Transaction> TransactionsAccountFrom { get; set; }
        public virtual ICollection<Transaction> TransactionsAccountTo { get; set; }

        public bool DepositOrWithdraw(double value, TypeTransaction typeTransaction)
        {
            switch (typeTransaction)
            {
                case TypeTransaction.Deposit:
                    Balance += value;
                    return true;
                case TypeTransaction.Withdraw:
                    if ((Balance - value) > 0)
                    {
                        Balance -= value;
                        return true;
                    }
                    return true;
                default:
                    return false;
            }
        }

    }
}
