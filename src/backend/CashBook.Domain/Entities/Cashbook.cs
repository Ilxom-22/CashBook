using CashBook.Domain.Common.Entities;

namespace CashBook.Domain.Entities;

public class Cashbook : Entity
{
    public string Name { get; set; } = default!;
}