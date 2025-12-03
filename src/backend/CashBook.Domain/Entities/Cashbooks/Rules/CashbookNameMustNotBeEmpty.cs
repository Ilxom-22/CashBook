using CashBook.Domain.Common;
using CashBook.Domain.Common.BusinessRule;

namespace CashBook.Domain.Entities.Rules;

public class CashbookNameMustNotBeEmpty(string cashbookName) : IBusinessRule
{
    public bool IsBroken() => string.IsNullOrWhiteSpace(cashbookName);

    public string Message => "Cashbook name must not be empty";
}