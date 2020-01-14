using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBankManager.Api.Requests.Account
{
    public class UpsertAccountRequest : AccountRequest
    {
        public string Name { get; set; }
        public string Document { get; set; }
    }
}
