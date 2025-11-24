using System.ComponentModel.DataAnnotations;
using CashBook.Domain.Common.Entities;

namespace CashBook.Domain.Entities.Categories;

public class Category : EntityBase
{
    [MaxLength(64)]
    public string Name { get; set; } = null!;
}