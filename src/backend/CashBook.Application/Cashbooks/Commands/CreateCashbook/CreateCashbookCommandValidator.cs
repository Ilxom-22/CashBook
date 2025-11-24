using FluentValidation;

namespace CashBook.Application.Cashbooks.Commands.CreateCashbook;

public class CreateCashbookCommandValidator : AbstractValidator<CreateCashbookCommand>
{
    public CreateCashbookCommandValidator()
    {
        RuleFor(x => x.CashbookName)
            .NotEmpty()
            .MaximumLength(100);
    }
}