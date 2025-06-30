using CashBook.Application.Cashbooks.Commands;
using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities;
using CashBook.Persistence.Repositories.Interfaces;
using FluentValidation;

namespace CashBook.Infrastructure.Cashbooks.CommandHandlers;

public class DeleteCashbookCommandHandler(
    ICashbookRepository cashbookRepository, 
    IValidator<DeleteCashbookCommand> validator) : ICommandHandler<DeleteCashbookCommand, Cashbook>
{
    public async Task<Cashbook> Handle(DeleteCashbookCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingCashbook = await cashbookRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (existingCashbook is null)
            throw new ArgumentException($"Cashbook with ID {request.Id} not found.");
        
        return await cashbookRepository.DeleteAsync(existingCashbook, true, cancellationToken);
    }
} 