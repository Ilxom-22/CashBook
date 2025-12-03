using CashBook.Domain.Common.Events;

namespace CashBook.Domain.Entities.Events;

public class CashbookMainAttributesUpdatedEvent(Guid cashbookId, string cashbookName) : EventBase
{
    public Guid CashbookId { get; set; } = cashbookId;

    public string CashbookName { get; set; } = cashbookName;
}