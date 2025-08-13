using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities;

namespace CashBook.Application.Cashbooks.Commands;

public class UpdateCashbookCommand : ICommand<Cashbook>
{
    public Guid Id { get; set; }
    public string CashbookName { get; set; } = null!;
} 