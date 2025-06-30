using CashBook.Application.Cashbooks.Commands;
using FluentValidation;

namespace CashBook.Infrastructure.Cashbooks.Validators;

public class DeleteCashbookCommandValidator : AbstractValidator<DeleteCashbookCommand>
{
    public DeleteCashbookCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
} 