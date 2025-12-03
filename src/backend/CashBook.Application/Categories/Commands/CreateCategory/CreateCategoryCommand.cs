using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities.Categories;

namespace CashBook.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : ICommand<Category>
{
    public string CategoryName { get; set; } = null!;
}