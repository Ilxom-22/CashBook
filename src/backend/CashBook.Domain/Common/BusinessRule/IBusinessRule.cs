namespace CashBook.Domain.Common.BusinessRule;

public interface IBusinessRule
{
    bool IsBroken();

    string Message { get; }
}