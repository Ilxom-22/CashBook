using System.ComponentModel.DataAnnotations;
using CashBook.Domain.Common.Entities;
using CashBook.Domain.Enums;

namespace CashBook.Domain.Entities;

public class Transaction : EntityBase
{
    public decimal Amount { get; set; }

    [MaxLength(500)]
    public string Remark { get; set; } = null!;

    public DateTime TransactionTime { get; set; }

    public PaymentMode PaymentMode { get; set; }

    public TransactionType TransactionType { get; set; }

    public Guid CategoryId { get; set; }

    public Guid CashbookId { get; set; }

    public virtual Cashbook Cashbook { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}