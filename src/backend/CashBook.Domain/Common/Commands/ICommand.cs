using MediatR;

namespace CashBook.Domain.Common.Commands;

public interface ICommand<out TResult> : ICommand, IRequest<TResult>
{
    
}

public interface ICommand
{
    
}