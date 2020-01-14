using MediatR;
using MyBankManager.Api.Requests.Transaction;
using MyBankManager.Api.Responses;
using MyBankManager.Domain.Interfaces;
using MyBankManager.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace MyBankManager.Api.Handlers.Commands
{
    public class RemoveTransactionRequestHandler : IRequestHandler<RemoveTransactionRequest, Response>
    {
        private readonly ITransactionRepository _TransactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RemoveTransactionRequestHandler(ITransactionRepository TransactionRepository, IUnitOfWork unitOfWork)
        {
            _TransactionRepository = TransactionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(RemoveTransactionRequest request, CancellationToken cancellationToken)
        {
            var Transaction = await _TransactionRepository.GetById(request.Id);
            if (Transaction == null)
                return new NotFoundResult($"Transaction not found to Transaction Id: {request.Id}");
            
            _TransactionRepository.Delete(Transaction);
            await _unitOfWork.SaveChangesAsync();

            return new OkResult($"Transaction {request.Id} remove sucessfully");
        }
    }
}
