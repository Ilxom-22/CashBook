using System.ComponentModel.DataAnnotations;
using CashBook.Domain.Common.Entities;

namespace CashBook.Domain.Entities;

public class Cashbook : Entity
{
    [MaxLength(100)]
    public string Name { get; set; } = null!;
}