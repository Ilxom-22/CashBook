using CashBook.Domain.Common.BusinessRule;
using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities;
using CashBook.Domain.Entities.Cashbooks;

namespace CashBook.Application.Cashbooks.Commands.DeleteCashbook;

public class DeleteCashbookCommandHandler(
    ICashbookRepository cashbookRepository) : ICommandHandler<DeleteCashbookCommand, Cashbook>
{
    public async Task<Cashbook> Handle(DeleteCashbookCommand request, CancellationToken cancellationToken)
    {
        var existingCashbook = await cashbookRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (existingCashbook is null)
            throw new ApplicationConsistencyValidationException($"Cashbook with ID {request.Id} not found.");
        
        return await cashbookRepository.DeleteAsync(existingCashbook, cancellationToken);
    }
} 