using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBankManager.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBankManager.Api.Requests.Account
{
    public class DepositOrWithdrawRequest : AccountRequest
    {
        public double Amount { get; set; }
        public TypeTransaction typeTransaction { get; set; }
    }
}
