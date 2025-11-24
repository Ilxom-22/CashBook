using AutoMapper;
using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities.Cashbooks;
using CashBook.Persistence.Repositories.Interfaces;

namespace CashBook.Application.Cashbooks.Commands.CreateCashbook;

public class CreateCashbookCommandHandler(
    ICashbookRepository cashbookRepository, 
    IMapper mapper) : ICommandHandler<CreateCashbookCommand, Cashbook>
{
    public async Task<Cashbook> Handle(CreateCashbookCommand request, CancellationToken cancellationToken)
    {
        var cashbook = mapper.Map<Cashbook>(request);
        return await cashbookRepository.CreateAsync(cashbook, cancellationToken);
    }
}