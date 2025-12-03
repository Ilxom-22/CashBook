using CashBook.Domain.Common.BusinessRule;
using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities;
using CashBook.Domain.Entities.Cashbooks;
using CashBook.Domain.Enums;

namespace CashBook.Application.Cashbooks.Commands.CreateCashbook;

public class CreateCashbookCommandHandler(
    ICashbookRepository cashbookRepository) : ICommandHandler<CreateCashbookCommand, Cashbook>
{
    public async Task<Cashbook> Handle(CreateCashbookCommand request, CancellationToken cancellationToken)
    {
        if (cashbookRepository.CashbookExistsByName(request.CashbookName))
        {
            throw new ApplicationConsistencyValidationException($"Cashbook with name {request.CashbookName} already exists");
        }
        
        var cashbook = Cashbook.Create(request.CashbookName, Enum.Parse<Currency>(request.Currency));
        
        return await cashbookRepository.CreateAsync(cashbook, cancellationToken);
    }
}