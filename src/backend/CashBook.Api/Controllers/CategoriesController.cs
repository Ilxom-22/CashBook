using CashBook.Application.Categories.Commands;
using CashBook.Application.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CashBook.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> GetCategories()
    {
        var categories = await mediator.Send(new GetCategoriesQuery());
        return Ok(categories);
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateCategory(string name, CancellationToken cancellationToken)
    {
        var result = await mediator
            .Send(new CreateCategoryCommand { CategoryName = name}, cancellationToken);
        
        return Ok(result);
    }
}