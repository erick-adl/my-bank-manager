using System;
using MediatR;
using MyBankManager.Api.Responses;

namespace MyBankManager.Api.Requests.Transaction
{
    public class TransactionAccountRequest: IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}