namespace CashBook.Domain.Common.BusinessRule;

public class ApplicationConsistencyValidationException(string message) : Exception(message)
{
    
}