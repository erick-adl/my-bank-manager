using MediatR;
using MyBankManager.Api.Responses;
using System;

namespace MyBankManager.Api.Requests.Account
{
    public class AccountRequest : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
