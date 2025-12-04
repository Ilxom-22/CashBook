using CashBook.Application.Categories.Queries;
using CashBook.Domain.Common.Queries;
using CashBook.Domain.Entities.Categories;

namespace CashBook.Infrastructure.Domain.Categories;

public class GetCategoriesQueryHandler(ICategoryRepository categoryRepository) 
    : IQueryHandler<GetCategoriesQuery, IQueryable<Category>>
{
    public Task<IQueryable<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = categoryRepository.Get();
        return Task.FromResult(categories);
    }
}