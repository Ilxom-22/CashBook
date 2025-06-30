using CashBook.Application.Cashbooks.Commands;
using FluentValidation;

namespace CashBook.Infrastructure.Cashbooks.Validators;

public class UpdateCashbookCommandValidator : AbstractValidator<UpdateCashbookCommand>
{
    public UpdateCashbookCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
            
        RuleFor(x => x.CashbookName)
            .NotEmpty()
            .MaximumLength(100);
    }
} 