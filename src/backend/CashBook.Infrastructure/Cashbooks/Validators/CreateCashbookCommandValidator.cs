using CashBook.Application.Cashbooks.Commands;
using FluentValidation;

namespace CashBook.Infrastructure.Cashbooks.Validators;

public class CreateCashbookCommandValidator : AbstractValidator<CreateCashbookCommand>
{
    public CreateCashbookCommandValidator()
    {
        RuleFor(x => x.CashbookName)
            .NotEmpty()
            .MaximumLength(100);
    }
}