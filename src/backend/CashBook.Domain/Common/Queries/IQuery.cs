using MediatR;

namespace CashBook.Domain.Common.Queries;

public interface IQuery<out TResult> : IQuery, IRequest<TResult>
{
    
}

public interface IQuery
{
    
}