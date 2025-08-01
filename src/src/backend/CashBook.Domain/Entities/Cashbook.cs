using System.ComponentModel.DataAnnotations;
using CashBook.Domain.Common.Entities;
using CashBook.Domain.Enums;

namespace CashBook.Domain.Entities;

public class Cashbook : AuditableEntity
{
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public decimal Balance { get; set; }

    public Currency Currency { get; set; }
}