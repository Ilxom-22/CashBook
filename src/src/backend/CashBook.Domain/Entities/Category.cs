using System.ComponentModel.DataAnnotations;
using CashBook.Domain.Common.Entities;

namespace CashBook.Domain.Entities;

public class Category : Entity
{
    [MaxLength(64)]
    public string Name { get; set; } = null!;
}