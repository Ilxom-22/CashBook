using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities;

namespace CashBook.Application.Categories.Commands;

public class CreateCategoryCommand : ICommand<Category>
{
    public string CategoryName { get; set; } = null!;
}