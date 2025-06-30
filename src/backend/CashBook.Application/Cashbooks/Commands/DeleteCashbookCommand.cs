using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities;

namespace CashBook.Application.Cashbooks.Commands;

public class DeleteCashbookCommand : ICommand<Cashbook>
{
    public Guid Id { get; set; }
} 