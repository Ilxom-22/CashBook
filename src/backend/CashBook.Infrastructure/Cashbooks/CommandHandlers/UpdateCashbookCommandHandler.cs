using AutoMapper;
using CashBook.Application.Cashbooks.Commands;
using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities;
using CashBook.Persistence.Repositories.Interfaces;
using FluentValidation;

namespace CashBook.Infrastructure.Cashbooks.CommandHandlers;

public class UpdateCashbookCommandHandler(
    ICashbookRepository cashbookRepository, 
    IValidator<UpdateCashbookCommand> validator,
    IMapper mapper) : ICommandHandler<UpdateCashbookCommand, Cashbook>
{
    public async Task<Cashbook> Handle(UpdateCashbookCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingCashbook = await cashbookRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (existingCashbook is null)
            throw new ArgumentException($"Cashbook with ID {request.Id} not found.");

        mapper.Map(request, existingCashbook);
        
        return await cashbookRepository.UpdateAsync(existingCashbook, true, cancellationToken);
    }
} 