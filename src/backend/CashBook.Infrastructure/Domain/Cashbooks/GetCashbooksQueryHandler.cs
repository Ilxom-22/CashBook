using CashBook.Application.Cashbooks.Queries;
using CashBook.Domain.Common.Queries;
using CashBook.Domain.Entities.Cashbooks;
using CashBook.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace CashBook.Infrastructure.Domain.Cashbooks;

public class GetCashbooksQueryHandler(AppDbContext dbContext) 
    : IQueryHandler<GetCashbooksQuery, IQueryable<Cashbook>>
{
    public Task<IQueryable<Cashbook>> Handle(GetCashbooksQuery request, CancellationToken cancellationToken)
    {
        var result = dbContext.CashBooks.AsNoTracking();
        
        return Task.FromResult(result);
    }
}