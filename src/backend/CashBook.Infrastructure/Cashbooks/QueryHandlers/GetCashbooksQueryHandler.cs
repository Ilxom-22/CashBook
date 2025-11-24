using CashBook.Application.Cashbooks.Queries;
using CashBook.Domain.Common.Queries;
using CashBook.Domain.Entities.Cashbooks;
using CashBook.Persistence.Repositories.Interfaces;

namespace CashBook.Infrastructure.Cashbooks.QueryHandlers;

public class GetCashbooksQueryHandler(ICashbookRepository cashbookRepository) 
    : IQueryHandler<GetCashbooksQuery, IQueryable<Cashbook>>
{
    public Task<IQueryable<Cashbook>> Handle(GetCashbooksQuery request, CancellationToken cancellationToken)
    {
        var result = cashbookRepository.Get(queryOptions: new QueryOptions(QueryTrackingMode.AsNoTracking));
        
        return Task.FromResult(result);
    }
}