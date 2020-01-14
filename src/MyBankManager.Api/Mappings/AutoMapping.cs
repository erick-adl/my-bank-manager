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
                .ForPath(des => des.User.Name, sor => sor.MapFrom(x => x.Name))
                .ForPath(des => des.User.Document, sor => sor.MapFrom(x => x.Document));

            CreateMap<Transaction, UpsertTransactionRequest>().ReverseMap();


        }
    }
}
