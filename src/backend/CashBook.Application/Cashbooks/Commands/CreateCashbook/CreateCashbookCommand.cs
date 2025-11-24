using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities.Cashbooks;

namespace CashBook.Application.Cashbooks.Commands.CreateCashbook;

public class CreateCashbookCommand : ICommand<Cashbook>
{
    public string CashbookName { get; set; } = null!;

    public string Currency { get; set; } = null!;
}