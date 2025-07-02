using CashBook.Mobile.Models;

namespace CashBook.Mobile.Services;

public interface ICashbookService
{
    Task<List<CashbookModel>> GetCashbooksAsync();
    Task<CashbookModel> CreateCashbookAsync(string name);
    Task<CashbookModel> UpdateCashbookAsync(Guid id, string name);
    Task<CashbookModel> DeleteCashbookAsync(Guid id);
} 