using AutoMapper;
using CashBook.Application.Cashbooks.Commands;
using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities;
using CashBook.Persistence.Repositories.Interfaces;

namespace CashBook.Infrastructure.Cashbooks.CommandHandlers;

public class UpdateCashbookCommandHandler(
    ICashbookRepository cashbookRepository, 
    IMapper mapper) : ICommandHandler<UpdateCashbookCommand, Cashbook>
{
    public async Task<Cashbook> Handle(UpdateCashbookCommand request, CancellationToken cancellationToken)
    {
        var existingCashbook = await cashbookRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (existingCashbook is null)
            throw new ArgumentException($"Cashbook with ID {request.Id} not found.");

        mapper.Map(request, existingCashbook);
        
        return await cashbookRepository.UpdateAsync(existingCashbook, cancellationToken);
    }
} 