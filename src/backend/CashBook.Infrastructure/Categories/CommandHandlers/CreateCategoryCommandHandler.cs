using CashBook.Application.Categories.Commands;
using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities;
using CashBook.Persistence.Repositories.Interfaces;

namespace CashBook.Infrastructure.Categories.CommandHandlers;

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository) : ICommandHandler<CreateCategoryCommand, Category>
{
    public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await categoryRepository
            .CreateAsync(new Category { Name = request.CategoryName}, cancellationToken);
    }
}