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
    private bool _isAddBookModalVisible = false;
    private string _newBookName = string.Empty;
    
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

    public bool IsAddBookModalVisible
    {
        get => _isAddBookModalVisible;
        set
        {
            _isAddBookModalVisible = value;
            OnPropertyChanged();
        }
    }

    public string NewBookName
    {
        get => _newBookName;
        set
        {
            _newBookName = value;
            OnPropertyChanged();
        }
    }
    
    public bool HasStatusMessage => !string.IsNullOrWhiteSpace(StatusMessage);
    
    // Commands
    public ICommand LoadCashbooksCommand { get; }
    public ICommand AddCashbookCommand { get; }
    public ICommand UpdateCashbookCommand { get; }
    public ICommand DeleteCashbookCommand { get; }
    public ICommand DismissStatusCommand { get; }
    public ICommand MenuTappedCommand { get; }
    public ICommand SearchTappedCommand { get; set; }
    public ICommand MenuButtonCommand { get; }
    public ICommand ShowAddBookModalCommand { get; }
    public ICommand CloseAddBookModalCommand { get; }
    public ICommand CreateBookCommand { get; }
    
    public MainPageViewModel(ICashbookService cashbookService)
    {
        _cashbookService = cashbookService;
        LoadCashbooksCommand = new Command(async () => await LoadCashbooksAsync());
        AddCashbookCommand = new Command<string>(async (name) => await AddCashbookAsync(name));
        UpdateCashbookCommand = new Command<(Guid id, string name)>(async (param) => await UpdateCashbookAsync(param.id, param.name));
        DeleteCashbookCommand = new Command<Guid>(async (id) => await DeleteCashbookAsync(id));
        DismissStatusCommand = new Command(DismissStatus);
        MenuTappedCommand = new Command(OnMenuTapped);
        SearchTappedCommand = new Command(OnSearchTapped);
        MenuButtonCommand = new Command<CashbookModel>(OnMenuButtonTapped);
        ShowAddBookModalCommand = new Command(OnShowAddBookModal);
        CloseAddBookModalCommand = new Command(OnCloseAddBookModal);
        CreateBookCommand = new Command<string>(async (name) => await OnCreateBook(name));
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

    private void OnMenuTapped()
    {
        // Handle menu tap - can show settings, about, etc.
        // For now, just show a simple message
        ShowSuccessMessage("Menu functionality coming soon!");
    }

    private void OnSearchTapped()
    {
        // This will be handled by the MainPage code-behind to show search bar
        // We could also implement search logic here if needed
    }

    private void OnMenuButtonTapped(CashbookModel cashbook)
    {
        if (cashbook == null) return;

        // For now, we'll implement a simple rename functionality
        // In a real app, this would show an action sheet with options
        // This is a simplified implementation for the refactored architecture
        
        // You can expand this to show proper action sheets later
        ShowSuccessMessage($"Options for {cashbook.Name} - Feature coming soon!");
    }

    private void OnShowAddBookModal()
    {
        NewBookName = string.Empty;
        IsAddBookModalVisible = true;
    }

    private void OnCloseAddBookModal()
    {
        IsAddBookModalVisible = false;
        NewBookName = string.Empty;
    }

    private async Task OnCreateBook(string name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            IsAddBookModalVisible = false;
            await AddCashbookAsync(name);
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