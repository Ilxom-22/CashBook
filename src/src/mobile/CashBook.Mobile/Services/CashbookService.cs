using System.Net.Http.Json;
using CashBook.Mobile.Models;

namespace CashBook.Mobile.Services;

public class CashbookService : ICashbookService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public CashbookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        
        // Use different URLs based on platform
#if ANDROID
        _baseUrl = "http://10.0.2.2:5262/api/cashbooks"; // Android emulator
#else
        _baseUrl = "http://localhost:5262/api/cashbooks"; // Other platforms
#endif
    }

    public async Task<List<CashbookModel>> GetCashbooksAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<CashbookModel>>(_baseUrl);
            return response ?? new List<CashbookModel>();
        }
        catch (HttpRequestException ex)
        {
            System.Diagnostics.Debug.WriteLine($"Network error getting cashbooks: {ex.Message}");
            throw new Exception("Unable to connect to the server. Please check your internet connection and ensure the backend is running.");
        }
        catch (TaskCanceledException ex)
        {
            System.Diagnostics.Debug.WriteLine($"Request canceled/timeout getting cashbooks: {ex.Message}");
            throw new Exception("Connection timeout. Please check if the backend is running and try again.");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error getting cashbooks: {ex.Message}");
            throw new Exception($"Failed to load cashbooks: {ex.Message}");
        }
    }

    public async Task<CashbookModel> CreateCashbookAsync(string name)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl, name);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CashbookModel>() ?? new CashbookModel();
        }
        catch (HttpRequestException ex)
        {
            System.Diagnostics.Debug.WriteLine($"Network error creating cashbook: {ex.Message}");
            throw new Exception("Unable to connect to the server. Please check your internet connection and ensure the backend is running.");
        }
        catch (TaskCanceledException ex)
        {
            System.Diagnostics.Debug.WriteLine($"Request canceled/timeout creating cashbook: {ex.Message}");
            throw new Exception("Connection timeout. Please check if the backend is running and try again.");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error creating cashbook: {ex.Message}");
            throw new Exception($"Failed to create cashbook: {ex.Message}");
        }
    }

    public async Task<CashbookModel> UpdateCashbookAsync(Guid id, string name)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", name);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CashbookModel>() ?? new CashbookModel();
        }
        catch (HttpRequestException ex)
        {
            System.Diagnostics.Debug.WriteLine($"Network error updating cashbook: {ex.Message}");
            throw new Exception("Unable to connect to the server. Please check your internet connection and ensure the backend is running.");
        }
        catch (TaskCanceledException ex)
        {
            System.Diagnostics.Debug.WriteLine($"Request canceled/timeout updating cashbook: {ex.Message}");
            throw new Exception("Connection timeout. Please check if the backend is running and try again.");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error updating cashbook: {ex.Message}");
            throw new Exception($"Failed to update cashbook: {ex.Message}");
        }
    }

    public async Task<CashbookModel> DeleteCashbookAsync(Guid id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CashbookModel>() ?? new CashbookModel();
        }
        catch (HttpRequestException ex)
        {
            System.Diagnostics.Debug.WriteLine($"Network error deleting cashbook: {ex.Message}");
            throw new Exception("Unable to connect to the server. Please check your internet connection and ensure the backend is running.");
        }
        catch (TaskCanceledException ex)
        {
            System.Diagnostics.Debug.WriteLine($"Request canceled/timeout deleting cashbook: {ex.Message}");
            throw new Exception("Connection timeout. Please check if the backend is running and try again.");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error deleting cashbook: {ex.Message}");
            throw new Exception($"Failed to delete cashbook: {ex.Message}");
        }
    }
} 