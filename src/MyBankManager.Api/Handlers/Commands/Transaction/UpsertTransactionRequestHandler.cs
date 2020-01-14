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
        private readonly ITransactionRepository _TransactionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertTransactionRequestHandler(ITransactionRepository TransactionRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _TransactionRepository = TransactionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(UpsertTransactionRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                await _TransactionRepository.Add(_mapper.Map<Transaction>(request));

            var Transaction = await _TransactionRepository.GetById(request.Id);
            if (Transaction != null)
                _mapper.Map(request, Transaction);
            else
                return new NotFoundResult($"Transaction not found to Transaction Id: {request.Id}");

            await _unitOfWork.SaveChangesAsync();
            return new OkResult("");
        }
    }
}
