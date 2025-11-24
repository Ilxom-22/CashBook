using CashBook.Application.Cashbooks.Commands.CreateCashbook;
using CashBook.Application.Cashbooks.Commands.DeleteCashbook;
using CashBook.Application.Cashbooks.Commands.UpdateCashbook;
using CashBook.Application.Cashbooks.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CashBook.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CashbooksController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var cashbooks = await mediator.Send(new GetCashbooksQuery());
        
        return Ok(cashbooks);
    }

    [HttpPost]
    public async ValueTask<IActionResult> AddCashbook(
        [FromBody] string cashbookName,
        [FromBody] string currency,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateCashbookCommand { CashbookName = cashbookName, Currency = currency }, cancellationToken);
        
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async ValueTask<IActionResult> UpdateCashbook(
        Guid id,
        [FromBody] string cashbookName,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateCashbookCommand { Id = id, CashbookName = cashbookName }, cancellationToken);
        
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async ValueTask<IActionResult> DeleteCashbook(
        Guid id,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new DeleteCashbookCommand { Id = id }, cancellationToken);
        
        return Ok(result);
    }
}