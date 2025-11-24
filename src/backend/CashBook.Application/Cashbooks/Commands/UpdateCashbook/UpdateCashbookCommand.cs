using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities.Cashbooks;

namespace CashBook.Application.Cashbooks.Commands.UpdateCashbook;

public class UpdateCashbookCommand : ICommand<Cashbook>
{
    public Guid Id { get; set; }
    public string CashbookName { get; set; } = null!;
} 