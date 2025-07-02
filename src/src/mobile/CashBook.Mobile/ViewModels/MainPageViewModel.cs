using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CashBook.Mobile.Models;
using CashBook.Mobile.Services;

namespace CashBook.Mobile.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    private readonly ICashbookService _cashbookService;
    private string _searchText = string.Empty;
    private bool _isLoading = false;
    private ObservableCollection<CashbookModel> _allCashbooks = new();
    private string _statusMessage = string.Empty;
    private bool _hasError = false;
    private bool _hasSuccess = false;
    
    public ObservableCollection<CashbookModel> Cashbooks { get; } = new();
    
    public string SearchText
    {
        get => _searchText;
        set
        {
            _searchText = value;
            OnPropertyChanged();
            FilterCashbooks();
        }
    }
    
    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged();
        }
    }
    
    public string StatusMessage
    {
        get => _statusMessage;
        set
        {
            _statusMessage = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(HasStatusMessage));
        }
    }
    
    public bool HasError
    {
        get => _hasError;
        set
        {
            _hasError = value;
            OnPropertyChanged();
        }
    }
    
    public bool HasSuccess
    {
        get => _hasSuccess;
        set
        {
            _hasSuccess = value;
            OnPropertyChanged();
        }
    }
    
    public bool HasStatusMessage => !string.IsNullOrWhiteSpace(StatusMessage);
    
    public ICommand LoadCashbooksCommand { get; }
    public ICommand AddCashbookCommand { get; }
    public ICommand UpdateCashbookCommand { get; }
    public ICommand DeleteCashbookCommand { get; }
    public ICommand DismissStatusCommand { get; }
    
    public MainPageViewModel(ICashbookService cashbookService)
    {
        _cashbookService = cashbookService;
        LoadCashbooksCommand = new Command(async () => await LoadCashbooksAsync());
        AddCashbookCommand = new Command<string>(async (name) => await AddCashbookAsync(name));
        UpdateCashbookCommand = new Command<(Guid id, string name)>(async (param) => await UpdateCashbookAsync(param.id, param.name));
        DeleteCashbookCommand = new Command<Guid>(async (id) => await DeleteCashbookAsync(id));
        DismissStatusCommand = new Command(DismissStatus);
    }
    
    private async Task LoadCashbooksAsync()
    {
        if (IsLoading) return;
        
        IsLoading = true;
        DismissStatus();
        
        try
        {
            var cashbooks = await _cashbookService.GetCashbooksAsync();
            _allCashbooks.Clear();
            foreach (var cashbook in cashbooks)
            {
                _allCashbooks.Add(cashbook);
            }
            FilterCashbooks();
            
            if (_allCashbooks.Count == 0)
            {
                // Don't show any message when list is empty - let user see the clean empty state
            }
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"Failed to load cashbooks: {ex.Message}");
        }
        finally
        {
            IsLoading = false;
        }
    }
    
    private async Task AddCashbookAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return;
        
        DismissStatus();
        
        try
        {
            var newCashbook = await _cashbookService.CreateCashbookAsync(name);
            _allCashbooks.Add(newCashbook);
            FilterCashbooks();
            ShowSuccessMessage($"Successfully created cashbook '{name}'.");
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"Failed to create cashbook: {ex.Message}");
        }
    }
    
    private async Task UpdateCashbookAsync(Guid id, string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return;
        
        DismissStatus();
        
        try
        {
            var updatedCashbook = await _cashbookService.UpdateCashbookAsync(id, name);
            var existingCashbook = _allCashbooks.FirstOrDefault(c => c.Id == id);
            if (existingCashbook != null)
            {
                var index = _allCashbooks.IndexOf(existingCashbook);
                _allCashbooks[index] = updatedCashbook;
                FilterCashbooks();
                ShowSuccessMessage($"Successfully renamed cashbook to '{name}'.");
            }
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"Failed to update cashbook: {ex.Message}");
        }
    }
    
    private async Task DeleteCashbookAsync(Guid id)
    {
        DismissStatus();
        
        try
        {
            await _cashbookService.DeleteCashbookAsync(id);
            var cashbookToRemove = _allCashbooks.FirstOrDefault(c => c.Id == id);
            if (cashbookToRemove != null)
            {
                var cashbookName = cashbookToRemove.Name;
                _allCashbooks.Remove(cashbookToRemove);
                FilterCashbooks();
                ShowSuccessMessage($"Successfully deleted cashbook '{cashbookName}'.");
            }
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"Failed to delete cashbook: {ex.Message}");
        }
    }
    
    private void FilterCashbooks()
    {
        Cashbooks.Clear();
        var filteredCashbooks = string.IsNullOrWhiteSpace(SearchText)
            ? _allCashbooks
            : _allCashbooks.Where(c => c.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
            
        foreach (var cashbook in filteredCashbooks)
        {
            Cashbooks.Add(cashbook);
        }
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private void ShowErrorMessage(string message)
    {
        System.Diagnostics.Debug.WriteLine($"[DEBUG] ShowErrorMessage: {message}");
        StatusMessage = message;
        HasError = true;
        HasSuccess = false;
        System.Diagnostics.Debug.WriteLine($"[DEBUG] StatusMessage set to: {StatusMessage}, HasError: {HasError}, HasStatusMessage: {HasStatusMessage}");
    }
    
    private void ShowSuccessMessage(string message)
    {
        System.Diagnostics.Debug.WriteLine($"[DEBUG] ShowSuccessMessage: {message}");
        StatusMessage = message;
        HasError = false;
        HasSuccess = true;
        System.Diagnostics.Debug.WriteLine($"[DEBUG] StatusMessage set to: {StatusMessage}, HasSuccess: {HasSuccess}, HasStatusMessage: {HasStatusMessage}");
    }
    
    private void DismissStatus()
    {
        StatusMessage = string.Empty;
        HasError = false;
        HasSuccess = false;
    }
    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
} 