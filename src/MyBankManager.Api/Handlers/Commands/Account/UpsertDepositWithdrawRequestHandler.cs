using AutoMapper;
using MediatR;
using MyBankManager.Api.Requests.Account;
using MyBankManager.Api.Responses;
using MyBankManager.Domain.Interfaces;
using MyBankManager.Domain.Entities;
using MyBankManager.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;
using MyBankManager.Domain.Models.Enums;

namespace MyBankManager.Api.Handlers.Commands
{
    public class UpsertDepositWithdrawRequestHandler : IRequestHandler<DepositOrWithdrawRequest, Response>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertDepositWithdrawRequestHandler(IAccountRepository accountRepository, ITransactionRepository transactionRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(DepositOrWithdrawRequest request, CancellationToken cancellationToken)
        {

            Account account = default;
            if (request.Amount == 0)
                return new NotFoundResult($"Amount not to be zero");
            if (request.Id == Guid.Empty)
                return new NotFoundResult($"Id not to be null");
            if (request.typeTransaction == TypeTransaction.Payment)
                return new NotFoundResult($"invalid Transaction");

            account = await _accountRepository.GetById(request.Id);
            if (account == null)
                return new NotFoundResult($"Account not found to Account Id: {request.Id}");
            else
            {
                if (account.DepositOrWithdraw(request.Amount, request.typeTransaction))
                {
                    var transation = new Transaction.Builder()
                    .FromAccountId(account.AccountId)
                    .ToAccountId(account.AccountId)
                    .WithTypeTransaction(request.typeTransaction)
                    .WithAmount(request.Amount)
                    .InTheTime(DateTime.Now)
                    .Build();

                    if (!transation.IsValid())
                        return new NotFoundResult($"Invalid Transaction");

                    await _transactionRepository.Add(transation);
                }
                else
                    return new NotFoundResult($"Invalid Transaction");
            }
            await _unitOfWork.SaveChangesAsync();
            return new OkResult("");
        }
    }
}
