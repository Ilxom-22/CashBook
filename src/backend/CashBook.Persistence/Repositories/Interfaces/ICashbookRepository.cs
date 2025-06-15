using System.Linq.Expressions;
using CashBook.Domain.Common.Queries;
using CashBook.Domain.Entities;

namespace CashBook.Persistence.Repositories.Interfaces;

public interface ICashbookRepository
{
    IQueryable<Cashbook> Get(Expression<Func<Cashbook, bool>>? predicate = null, QueryOptions queryOptions = default);
    
    ValueTask<Cashbook> CreateAsync(Cashbook cashbook, bool saveChanges = true, CancellationToken cancellationToken = default);
}