using AutoMapper;
using CashBook.Application.Cashbooks.Commands;
using CashBook.Domain.Common.Commands;
using CashBook.Domain.Entities;
using CashBook.Persistence.Repositories.Interfaces;

namespace CashBook.Infrastructure.Cashbooks.CommandHandlers;

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