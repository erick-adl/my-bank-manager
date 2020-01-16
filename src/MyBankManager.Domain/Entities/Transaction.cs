using System;
using MyBankManager.Domain.ValueObjects.Enums;


namespace MyBankManager.Domain.Entities
{
    public class Transaction
    {
        public Transaction(Guid accountFromId, Account accountFrom, TypeTransaction typeTransaction, string description, double amount, DateTime dateAndTime, Guid accountToId = default, Account accountTo = default)
        {
            AccountFromId = accountFromId;
            AccountToId = accountToId;
            AccountFrom = accountFrom;
            AccountTo = accountTo;
            TypeTransaction = typeTransaction;
            Description = description;
            Amount = amount;
            DateAndTime = dateAndTime;
        }

        protected Transaction()
        {

        }


        public Guid TransactionId { get; set; }
        public Guid AccountFromId { get; set; }
        public Guid AccountToId { get; set; }
        public virtual Account AccountFrom { get; set; }
        public virtual Account AccountTo { get; set; }
        public TypeTransaction TypeTransaction { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DateAndTime { get; set; }

    }
}
