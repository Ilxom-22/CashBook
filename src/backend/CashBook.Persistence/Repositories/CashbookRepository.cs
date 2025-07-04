using System.Linq.Expressions;
using CashBook.Domain.Common.Queries;
using CashBook.Domain.Entities;
using CashBook.Persistence.DataContexts;
using CashBook.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public new async ValueTask<Cashbook> UpdateAsync(Cashbook cashbook, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(cashbook, saveChanges, cancellationToken);
    }

    public new async ValueTask<Cashbook> DeleteAsync(Cashbook cashbook, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(cashbook, saveChanges, cancellationToken);
    }

    public async ValueTask<Cashbook?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Get(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
    }
}