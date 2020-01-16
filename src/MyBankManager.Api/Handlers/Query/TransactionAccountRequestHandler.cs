using MediatR;
using MyBankManager.Api.Requests.Transaction;
using MyBankManager.Api.Responses;
using MyBankManager.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBankManager.Api.Handlers.Query
{
    public class TransactionAccountRequestHandler : IRequestHandler<TransactionAccountRequest, Response>
    {
        private readonly ITransactionRepository _TransactionRepository;
        public TransactionAccountRequestHandler(ITransactionRepository TransactionRepository) => _TransactionRepository = TransactionRepository;
        public async Task<Response> Handle(TransactionAccountRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                return new Response(await _TransactionRepository.Get());

            return new Response(await _TransactionRepository.GetByAccountId(request.Id));
        }
    }
}
