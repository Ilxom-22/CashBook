using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities;

namespace CashBook.Application.Cashbooks.Commands;

public class CreateCashbookCommand : ICommand<Cashbook>
{
    public string CashbookName { get; set; } = null!;
}