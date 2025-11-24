using FluentValidation;

namespace CashBook.Application.Cashbooks.Commands.UpdateCashbook;

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