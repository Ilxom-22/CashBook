using CashBook.Domain.Common.Queries;
using CashBook.Domain.Entities.Categories;
using CashBook.Persistence.Repositories.Interfaces;

namespace CashBook.Application.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler(ICategoryRepository categoryRepository) 
    : IQueryHandler<GetCategoriesQuery, IQueryable<Category>>
{
    public Task<IQueryable<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = categoryRepository.Get();
        return Task.FromResult(categories);
    }
}