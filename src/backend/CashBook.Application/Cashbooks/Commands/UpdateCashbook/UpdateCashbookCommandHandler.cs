using AutoMapper;
using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities.Cashbooks;
using CashBook.Persistence.Repositories.Interfaces;

namespace CashBook.Application.Cashbooks.Commands.UpdateCashbook;

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