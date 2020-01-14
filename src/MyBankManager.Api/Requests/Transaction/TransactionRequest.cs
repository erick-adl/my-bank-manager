using MediatR;
using MyBankManager.Api.Responses;
using System;

namespace MyBankManager.Api.Requests.Transaction
{
    public class TransactionRequest : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
