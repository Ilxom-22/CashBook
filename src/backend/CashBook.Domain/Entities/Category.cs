using CashBook.Domain.Common.Entities;

namespace CashBook.Domain.Entities;

public class Category : Entity
{
    public string Name { get; set; } = default!;
}