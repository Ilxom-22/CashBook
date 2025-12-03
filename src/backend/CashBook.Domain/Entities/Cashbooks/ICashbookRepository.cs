using CashBook.Domain.Entities.Cashbooks;

namespace CashBook.Domain.Entities;

public interface ICashbookRepository
{
    bool CashbookExistsByName(string cashbookName);
    
    ValueTask<Cashbook> CreateAsync(Cashbook cashbook, CancellationToken cancellationToken, bool saveChanges = true);

    ValueTask<Cashbook> UpdateAsync(Cashbook cashbook, CancellationToken cancellationToken, bool saveChanges = true);

    ValueTask<Cashbook> DeleteAsync(Cashbook cashbook, CancellationToken cancellationToken, bool saveChanges = true);

    ValueTask<Cashbook?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}