using System.Linq.Expressions;
using CashBook.Domain.Common.Queries;
using CashBook.Domain.Entities;
using CashBook.Persistence.DataContexts;
using CashBook.Persistence.Repositories.Interfaces;

namespace CashBook.Persistence.Repositories;

public class CategoryRepository(AppDbContext context) 
    : EntityRepositoryBase<AppDbContext, Category>(context),
        ICategoryRepository
{
    public new IQueryable<Category> Get(Expression<Func<Category, bool>>? predicate = null, QueryOptions queryOptions = default)
    {
        return base.Get(predicate, queryOptions);
    }
    
    public new async ValueTask<Category> CreateAsync(Category category, CancellationToken cancellationToken, bool saveChanges = true)
    {
        return await base.CreateAsync(category, saveChanges, cancellationToken);
    }

    public bool ExistsByName(string categoryName)
    {
        var category = Get(x => x.Name == categoryName).FirstOrDefault();
        return category != null;
    }
}