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

namespace MyBankManager.Api.Handlers.Commands
{
    public class UpsertAccountRequestHandler : IRequestHandler<UpsertAccountRequest, Response>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertAccountRequestHandler(IAccountRepository AccountRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _accountRepository = AccountRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(UpsertAccountRequest request, CancellationToken cancellationToken)
        {
            Account account = default;
            if (request.Id == Guid.Empty)
            {
                account = _mapper.Map<Account>(request);
                await _accountRepository.Add(account);
            }
            else
            {
                account = await _accountRepository.GetById(request.Id);
                if (account != null)
                    _mapper.Map(request, account);
                else
                    return new NotFoundResult($"Account not found to Account Id: {request.Id}");
            }
            await _unitOfWork.SaveChangesAsync();
            return new OkResult(account);
        }
    }
}
