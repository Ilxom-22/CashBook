using System.Linq.Expressions;
using CashBook.Domain.Common.Queries;
using CashBook.Domain.Entities.Cashbooks;

namespace CashBook.Persistence.Repositories.Interfaces;

public interface ICashbookRepository
{
    IQueryable<Cashbook> Get(Expression<Func<Cashbook, bool>>? predicate = null, QueryOptions queryOptions = default);
    
    ValueTask<Cashbook> CreateAsync(Cashbook cashbook, CancellationToken cancellationToken, bool saveChanges = true);

    ValueTask<Cashbook> UpdateAsync(Cashbook cashbook, CancellationToken cancellationToken, bool saveChanges = true);

    ValueTask<Cashbook> DeleteAsync(Cashbook cashbook, CancellationToken cancellationToken, bool saveChanges = true);

    ValueTask<Cashbook?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}