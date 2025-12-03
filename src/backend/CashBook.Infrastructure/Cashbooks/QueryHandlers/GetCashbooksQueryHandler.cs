using CashBook.Application.Cashbooks.Queries;
using CashBook.Domain.Common.Queries;
using CashBook.Domain.Entities.Cashbooks;
using CashBook.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace CashBook.Infrastructure.Cashbooks.QueryHandlers;

public class GetCashbooksQueryHandler(AppDbContext dbContext) 
    : IQueryHandler<GetCashbooksQuery, IQueryable<Cashbook>>
{
    public Task<IQueryable<Cashbook>> Handle(GetCashbooksQuery request, CancellationToken cancellationToken)
    {
        var result = dbContext.CashBooks.AsNoTracking();
        
        return Task.FromResult(result);
    }
}