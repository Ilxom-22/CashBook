using System.Linq.Expressions;
using CashBook.Domain.Common.Queries;
using CashBook.Domain.Entities;
using CashBook.Persistence.DataContexts;
using CashBook.Persistence.Repositories.Interfaces;

namespace CashBook.Persistence.Repositories;

public class CashbookRepository(AppDbContext dbContext) : EntityRepositoryBase<AppDbContext, Cashbook>(dbContext),
    ICashbookRepository
{
    public new IQueryable<Cashbook> Get(Expression<Func<Cashbook, bool>>? predicate = null, QueryOptions queryOptions = default)
    {
        return base.Get(predicate, queryOptions);
    }

    public new async ValueTask<Cashbook> CreateAsync(Cashbook cashbook, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(cashbook, saveChanges, cancellationToken);
    }
}