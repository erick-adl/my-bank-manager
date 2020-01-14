using MediatR;
using MyBankManager.Api.Requests.Account;
using MyBankManager.Api.Responses;
using MyBankManager.Domain.Interfaces;
using MyBankManager.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace MyBankManager.Api.Handlers.Commands
{
    public class RemoveAccountRequestHandler : IRequestHandler<RemoveAccountRequest, Response>
    {
        private readonly IAccountRepository _AccountRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RemoveAccountRequestHandler(IAccountRepository AccountRepository, IUnitOfWork unitOfWork)
        {
            _AccountRepository = AccountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(RemoveAccountRequest request, CancellationToken cancellationToken)
        {
            var Account = await _AccountRepository.GetById(request.Id);
            if (Account == null)
                return new NotFoundResult($"Account not found to Account Id: {request.Id}");
            
            _AccountRepository.Delete(Account);
            await _unitOfWork.SaveChangesAsync();

            return new OkResult($"Account {request.Id} remove sucessfully");
        }
    }
}
