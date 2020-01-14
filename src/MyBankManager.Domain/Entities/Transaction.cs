using System;

namespace MyBankManager.Domain.Entities
{
    public class Transaction
    {
        protected Transaction()
        {

        }

        public Transaction(Guid transactionId, Guid accountId, Account account, string description, double amount, DateTime dateAndTime = default)
        {
            this.TransactionId = transactionId;
            this.AccountId = accountId;
            this.Account = account;
            this.Description = description;
            this.Amount = amount;
            this.DateAndTime = dateAndTime;

        }
        public Guid TransactionId { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DateAndTime { get; set; }

    }
}
