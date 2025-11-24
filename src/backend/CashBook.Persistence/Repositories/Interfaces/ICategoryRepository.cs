using System.Linq.Expressions;
using CashBook.Domain.Common.Queries;
using CashBook.Domain.Entities;
using CashBook.Domain.Entities.Categories;

namespace CashBook.Persistence.Repositories.Interfaces;

public interface ICategoryRepository
{
    IQueryable<Category> Get(Expression<Func<Category, bool>>? predicate = null, QueryOptions queryOptions = default);
    
    ValueTask<Category> CreateAsync(Category category, CancellationToken cancellationToken, bool saveChanges = true);
    
    bool ExistsByName(string categoryName);
}