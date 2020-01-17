using FluentValidation;
using MyBankManager.Domain.Entities;

namespace MyBankManager.Domain.Validations
{
    public class TransactionValidation : AbstractValidator<Transaction>
    {
        public TransactionValidation()
        {
            ValidateAccountFromId();
            ValidateAccountToId();
            ValidateTypeTransaction();
            ValidateAmount();
        }
        private void ValidateAccountFromId()
        {
           RuleFor(a => a.AccountFromId).NotEmpty().NotNull().WithMessage("Please, fill in the account from");
        }
        private void ValidateAccountToId()
        {
           RuleFor(a => a.AccountToId).NotEmpty().NotNull().WithMessage("Please, fill in the account to");
        }
        private void ValidateTypeTransaction()
        {
           RuleFor(a => a.TypeTransaction).NotEmpty().NotNull().WithMessage("Please, choose type transaction");
        }

        private void ValidateAmount()
        {
           RuleFor(a => a.Amount).NotEmpty().NotNull().WithMessage("Please, fill in the date and time").GreaterThan(0).WithMessage("Amount must to be greater than zero");
        }
    }
}