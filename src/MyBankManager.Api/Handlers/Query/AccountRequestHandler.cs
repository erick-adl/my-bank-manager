using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBankManager.Api.Requests.Account;
using MyBankManager.Api.Responses;
using MyBankManager.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBankManager.Api.Handlers.Query
{
    public class AccountRequestHandler : IRequestHandler<AccountRequest, Response>
    {
        private readonly IAccountRepository _AccountRepository;
        public AccountRequestHandler(IAccountRepository AccountRepository) => _AccountRepository = AccountRepository;
        public async Task<Response> Handle(AccountRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                return new Response(await _AccountRepository.Get());

            return new Response(await _AccountRepository.GetById(request.Id));
        }
    }
}
