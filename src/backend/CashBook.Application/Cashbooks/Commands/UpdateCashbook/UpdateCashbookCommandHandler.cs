using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities;
using CashBook.Domain.Entities.Cashbooks;

namespace CashBook.Application.Cashbooks.Commands.UpdateCashbook;

public class UpdateCashbookCommandHandler(
    ICashbookRepository cashbookRepository) : ICommandHandler<UpdateCashbookCommand, Cashbook>
{
    public async Task<Cashbook> Handle(UpdateCashbookCommand request, CancellationToken cancellationToken)
    {
        var existingCashbook = await cashbookRepository.GetByIdAsync(request.CashbookId, cancellationToken);
        
        if (existingCashbook is null)
            throw new ArgumentException($"Cashbook with ID {request.CashbookId} not found.");
        
        existingCashbook.UpdateMainAttributes(request.CashbookName);
        
        return await cashbookRepository.UpdateAsync(existingCashbook, cancellationToken);
    }
}
