using System.ComponentModel.DataAnnotations;
using CashBook.Domain.Common.Entities;
using CashBook.Domain.Enums;

namespace CashBook.Domain.Entities.Cashbooks;

public class Cashbook : AuditableEntity, IAggregateRoot
{
    [MaxLength(100)]
    public string Name { get; set; }

    public decimal Balance { get; set; }

    public Currency Currency { get; set; }

    private Cashbook(string cashbookName, Currency currency)
    {
        this.Name = cashbookName;
        this.Currency = currency;
        this.Balance = 0;
    }
    
    public static Cashbook Create(string cashbookName, Currency currency)
    {
        return new Cashbook(cashbookName, currency);
    }

    public Cashbook UpdateCashbookName(string newCashbookName)
    {
        this.Name = newCashbookName;
        return this;
    }

    public Cashbook UpdateCurrency(Currency currency)
    {
        this.Currency = currency;
        return this;
    }
}