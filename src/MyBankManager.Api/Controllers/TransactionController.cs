

using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBankManager.Api.Controllers.Extensions;
using MyBankManager.Api.Requests.Transaction;

namespace MyBankManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly IMediator _mediator;
        public TransactionController(IMediator mediator) => _mediator = mediator;

        // GET: api/Transaction
        [HttpGet]
        public async Task<IActionResult> Get() => this.ToActionResult(await _mediator.Send(new TransactionRequest()));

        // GET: api/Transaction/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => this.ToActionResult(await _mediator.Send(new TransactionRequest { Id = id }));

        // GET: api/Transaction/Account/5
        [HttpGet("Account/{id}")]
        public async Task<IActionResult> GetByAccountId(Guid id) => this.ToActionResult(await _mediator.Send(new TransactionAccountRequest { Id = id }));

        // POST: api/Transaction
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UpsertTransactionRequest request) => this.ToActionResult(await _mediator.Send(request));

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return this.ToActionResult(await _mediator.Send(new RemoveTransactionRequest { Id = id }));
        }

        // PUT: api/Transaction/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpsertTransactionRequest request)
        {
            request.Id = id;
            return this.ToActionResult(await _mediator.Send(request));
        }

    }
}
