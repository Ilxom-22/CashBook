using AutoMapper;
using CashBook.Application.Cashbooks.Commands;
using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities;
using CashBook.Persistence.Repositories.Interfaces;
using FluentValidation;

namespace CashBook.Infrastructure.Cashbooks.CommandHandlers;

public class CreateCashbookCommandHandler(
    ICashbookRepository cashbookRepository, 
    IValidator<CreateCashbookCommand> validator,
    IMapper mapper) : ICommandHandler<CreateCashbookCommand, Cashbook>
{
    public async Task<Cashbook> Handle(CreateCashbookCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var cashbook = mapper.Map<Cashbook>(request);
        return await cashbookRepository.CreateAsync(cashbook, true, cancellationToken);
    }
}