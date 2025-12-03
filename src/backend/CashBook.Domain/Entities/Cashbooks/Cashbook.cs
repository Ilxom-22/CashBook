using System.ComponentModel.DataAnnotations;
using CashBook.Domain.Common.Entities;
using CashBook.Domain.Entities.Events;
using CashBook.Domain.Entities.Rules;
using CashBook.Domain.Enums;

namespace CashBook.Domain.Entities.Cashbooks;

public class Cashbook : AuditableEntity, IAggregateRoot
{
    [MaxLength(100)]
    public string Name { get; private set; }

    public decimal Balance { get; private set; }

    public Currency Currency { get; private set; }
    
    // for EF Core
    protected Cashbook() { }

    private Cashbook(string cashbookName, Currency currency)
    {
        CheckRule(new CashbookNameMustNotBeEmpty(cashbookName));
        
        this.Name = cashbookName;
        this.Currency = currency;
        this.Balance = 0;
        
        AddDomainEvent(new NewCashbookCreatedEvent(this.Id, this.Name, this.Currency));
    }
    
    public static Cashbook Create(string cashbookName, Currency currency)
    {
        return new Cashbook(cashbookName, currency);
    }

    public void UpdateMainAttributes(string newCashbookName)
    {
        CheckRule(new CashbookNameMustNotBeEmpty(newCashbookName));
        
        this.Name = newCashbookName;
        AddDomainEvent(new CashbookMainAttributesUpdatedEvent(this.Id, this.Name));
    }
}