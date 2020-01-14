using AutoMapper;
using MediatR;
using MyBankManager.Api.Requests.Account;
using MyBankManager.Api.Responses;
using MyBankManager.Domain.Interfaces;
using MyBankManager.Domain.Entities;
using MyBankManager.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBankManager.Api.Handlers.Commands
{
    public class UpsertAccountRequestHandler : IRequestHandler<UpsertAccountRequest, Response>
    {
        private readonly IAccountRepository _AccountRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertAccountRequestHandler(IAccountRepository AccountRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _AccountRepository = AccountRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(UpsertAccountRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                var map = _mapper.Map<Account>(request);
                await _AccountRepository.Add(map);
                await _unitOfWork.SaveChangesAsync();
                return new OkResult("");
            }

            var Account = await _AccountRepository.GetById(request.Id);
            if (Account != null)
                _mapper.Map(request, Account);
            else
                return new NotFoundResult($"Account not found to Account Id: {request.Id}");

            await _unitOfWork.SaveChangesAsync();
            return new OkResult("");
        }
    }
}
