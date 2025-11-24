using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities.Cashbooks;

namespace CashBook.Application.Cashbooks.Commands.DeleteCashbook;

public class DeleteCashbookCommand : ICommand<Cashbook>
{
    public Guid Id { get; set; }
} 