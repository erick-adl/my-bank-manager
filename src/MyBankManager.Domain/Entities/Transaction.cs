using System;
using MyBankManager.Domain.Models;
using MyBankManager.Domain.Models.Enums;
using MyBankManager.Domain.Validations;

namespace MyBankManager.Domain.Entities
{
    public class Transaction : ValueObject<Transaction>
    {
        public Transaction(Guid accountFromId, TypeTransaction typeTransaction, string description, double amount, DateTime dateAndTime, Guid accountToId = default)
        {
            AccountFromId = accountFromId;
            AccountToId = accountToId;
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

        public override bool IsValid()
        {
            ValidationResult = new TransactionValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class Builder
        {
            private readonly Transaction _transaction = new Transaction();

            public Transaction Build()
            {
                return _transaction;
            }

            public Builder FromAccountId(Guid accountFromId)
            {
                _transaction.AccountFromId = accountFromId;
                return this;
            }

            public Builder ToAccountId(Guid accountToId)
            {
                _transaction.AccountToId = accountToId;
                return this;
            }

            public Builder WithTypeTransaction(TypeTransaction typeTransaction)
            {
                _transaction.TypeTransaction = typeTransaction;
                _transaction.Description = _transaction.TypeTransaction.ToString();
                return this;
            }

            public Builder WithAmount(double value)
            {
                _transaction.Amount = value;
                return this;
            }

             public Builder InTheTime(DateTime dateTime)
            {
                _transaction.DateAndTime = dateTime;
                return this;
            }

        }

    }
}
