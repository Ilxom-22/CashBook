using CashBook.Mobile.ViewModels;

namespace CashBook.Mobile;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel _viewModel;

    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
        
        // Override SearchTappedCommand to handle search bar visibility
        _viewModel.SearchTappedCommand = new Command(OnSearchTapped);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadCashbooksCommand.Execute(null);
    }

    private void OnSearchTapped()
    {
        ShowSearchBar();
    }

    private void OnSearchTapped(object sender, EventArgs e)
    {
        ShowSearchBar();
    }

    private void OnSearchCloseTapped(object sender, EventArgs e)
    {
        SearchFrame.IsVisible = false;
        _viewModel.SearchText = string.Empty;
        SearchEntry.Unfocus();
    }

    public void ShowSearchBar()
    {
        SearchFrame.IsVisible = true;
        SearchEntry.Focus();
    }
}

