using MediatR;
using MyBankManager.Api.Requests.Transaction;
using MyBankManager.Api.Responses;
using MyBankManager.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBankManager.Api.Handlers.Query
{
    public class TransactionRequestHandler : IRequestHandler<TransactionRequest, Response>
    {
        private readonly ITransactionRepository _TransactionRepository;
        public TransactionRequestHandler(ITransactionRepository TransactionRepository) => _TransactionRepository = TransactionRepository;
        public async Task<Response> Handle(TransactionRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                return new Response(await _TransactionRepository.Get());

            return new Response(await _TransactionRepository.GetById(request.Id));
        }
    }
}
