using System.Linq.Expressions;
using CashBook.Domain.Common.Queries;
using CashBook.Domain.Entities;

namespace CashBook.Persistence.Repositories.Interfaces;

public interface ICategoryRepository
{
    IQueryable<Category> Get(Expression<Func<Category, bool>>? predicate = null, QueryOptions queryOptions = default);
    ValueTask<Category> CreateAsync(Category category, bool saveChanges = true, CancellationToken cancellationToken = default);
    bool ExistsByName(string categoryName);
}