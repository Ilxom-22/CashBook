using CashBook.Application.Categories.Commands;
using CashBook.Persistence.Repositories.Interfaces;
using FluentValidation;

namespace CashBook.Infrastructure.Categories.Validators;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
    {
        RuleFor(x => x.CategoryName)
            .NotEmpty()
            .WithMessage("Category Name is required")
            .MaximumLength(64)
            .WithMessage("Category Name must not exceed 64 characters")
            .Must(name => !categoryRepository.ExistsByName(name))
            .WithMessage("Category with name '{PropertyValue}' already exists");
    }
}