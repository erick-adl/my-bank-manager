using AutoMapper;
using MyBankManager.Api.Requests.Account;
using MyBankManager.Api.Requests.Transaction;
using MyBankManager.Domain.Entities;

namespace MyBankManager.Api.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Account, UpsertAccountRequest>().ReverseMap()
                .ForPath(des => des.Client.Name, sor => sor.MapFrom(x => x.Name))
                .ForPath(des => des.Client.Document, sor => sor.MapFrom(x => x.Document));

            CreateMap<Transaction, UpsertTransactionRequest>().ReverseMap();


        }
    }
}
