using AutoMapper;
using MediatR;
using MyBankManager.Api.Requests.Transaction;
using MyBankManager.Api.Responses;
using MyBankManager.Domain.Interfaces;
using MyBankManager.Domain.Entities;
using MyBankManager.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBankManager.Api.Handlers.Commands
{
    public class UpsertTransactionRequestHandler : IRequestHandler<UpsertTransactionRequest, Response>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertTransactionRequestHandler(ITransactionRepository TransactionRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _transactionRepository = TransactionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(UpsertTransactionRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                await _transactionRepository.Add(_mapper.Map<Transaction>(request));

            var transaction = await _transactionRepository.GetById(request.Id);
            if (transaction != null)
                _mapper.Map(request, transaction);
            else
                return new NotFoundResult($"Transaction not found to Transaction Id: {request.Id}");

            await _unitOfWork.SaveChangesAsync();
            return new OkResult("");
        }
    }
}
