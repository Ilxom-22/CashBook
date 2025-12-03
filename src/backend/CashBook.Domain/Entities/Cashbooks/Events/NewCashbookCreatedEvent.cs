using CashBook.Domain.Common.Events;
using CashBook.Domain.Enums;

namespace CashBook.Domain.Entities.Events;

public class NewCashbookCreatedEvent(Guid cashbookId, string cashbookName, Currency currency) : EventBase
{
    public Guid CashbookId { get; set; } = cashbookId;
    
    public string CashbookName { get; } = cashbookName;

    public Currency Currency { get; } = currency;
}