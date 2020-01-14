

using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBankManager.Api.Controllers.Extensions;
using MyBankManager.Api.Requests.Account;

namespace MyBankManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator) => _mediator = mediator;

        // GET: api/Account
        [HttpGet]
        public async Task<IActionResult> Get() => this.ToActionResult(await _mediator.Send(new AccountRequest()));

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => this.ToActionResult(await _mediator.Send(new AccountRequest { Id = id }));

        // POST: api/Account
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UpsertAccountRequest request) => this.ToActionResult(await _mediator.Send(request));

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return this.ToActionResult(await _mediator.Send(new RemoveAccountRequest { Id = id}));
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpsertAccountRequest request)
        {
            request.Id = id;
            return this.ToActionResult(await _mediator.Send(request));
        }

    }
}
