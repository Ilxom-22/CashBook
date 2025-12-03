using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities.Categories;
using CashBook.Persistence.Repositories.Interfaces;

namespace CashBook.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository) : ICommandHandler<CreateCategoryCommand, Category>
{
    public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await categoryRepository
            .CreateAsync(new Category { Name = request.CategoryName}, cancellationToken);
    }
}