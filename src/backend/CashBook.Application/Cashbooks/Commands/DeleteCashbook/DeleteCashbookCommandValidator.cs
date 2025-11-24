using FluentValidation;

namespace CashBook.Application.Cashbooks.Commands.DeleteCashbook;

public class DeleteCashbookCommandValidator : AbstractValidator<DeleteCashbookCommand>
{
    public DeleteCashbookCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
} 