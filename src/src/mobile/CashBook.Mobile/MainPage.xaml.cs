using CashBook.Mobile.Models;
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
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.LoadCashbooksCommand.Execute(null);
	}

	private async void OnAddNewBookClicked(object sender, EventArgs e)
	{
		await ShowAddBookModal();
	}

	private async Task ShowAddBookModal()
	{
		// Clear previous input
		BookNameEntry.Text = string.Empty;
		
		// Show modal background and modal
		ModalBackground.IsVisible = true;
		AddBookModal.IsVisible = true;
		
		// Animate slide up from bottom
		await AddBookModal.TranslateTo(0, 0, 250, Easing.CubicOut);
		
		// Focus on input (this will bring up the keyboard)
		BookNameEntry.Focus();
	}

	private async void OnCloseModalClicked(object sender, EventArgs e)
	{
		await HideAddBookModal();
	}

	private async void OnModalBackgroundTapped(object sender, EventArgs e)
	{
		await HideAddBookModal();
	}

	private async Task HideAddBookModal()
	{
		// Unfocus input first (this will hide the keyboard)
		BookNameEntry.Unfocus();
		
		// Small delay to let keyboard hide
		await Task.Delay(100);
		
		// Animate slide down
		await AddBookModal.TranslateTo(0, 300, 250, Easing.CubicIn);
		
		// Hide modal and background
		AddBookModal.IsVisible = false;
		ModalBackground.IsVisible = false;
	}

	private async void OnCreateBookClicked(object sender, EventArgs e)
	{
		await CreateNewBook();
	}

	private async void OnBookNameEntryCompleted(object sender, EventArgs e)
	{
		await CreateNewBook();
	}

	private async Task CreateNewBook()
	{
		string? name = BookNameEntry.Text?.Trim();
		if (!string.IsNullOrWhiteSpace(name))
		{
			// Hide modal first
			await HideAddBookModal();
			
			// Create the cashbook
			_viewModel.AddCashbookCommand.Execute(name);
		}
		else
		{
			await DisplayAlert("Invalid Name", "Please enter a valid cashbook name.", "OK");
		}
	}

	private async void OnMenuButtonClicked(object sender, EventArgs e)
	{
		CashbookModel? cashbook = null;
		
		// Get the binding context from the sender (Label)
		if (sender is Label label && label.BindingContext is CashbookModel labelCashbook)
		{
			cashbook = labelCashbook;
		}

		if (cashbook != null)
		{
			string action = await DisplayActionSheet($"Options for {cashbook.Name}", "Cancel", null, "Rename book", "Delete book");
			
			switch (action)
			{
				case "Rename book":
					string newName = await DisplayPromptAsync("Rename Cashbook", "Enter new name:", "Update", "Cancel", cashbook.Name);
					if (!string.IsNullOrWhiteSpace(newName) && newName != cashbook.Name)
					{
						_viewModel.UpdateCashbookCommand.Execute((cashbook.Id, newName));
					}
					break;
					
				case "Delete book":
					bool confirm = await DisplayAlert("Delete Cashbook", $"Are you sure you want to delete '{cashbook.Name}'?", "Delete", "Cancel");
					if (confirm)
					{
						_viewModel.DeleteCashbookCommand.Execute(cashbook.Id);
					}
					break;
			}
		}
	}

	private void OnSearchTapped(object sender, EventArgs e)
	{
		SearchFrame.IsVisible = true;
		SearchEntry.Focus();
	}

	private void OnSearchCloseTapped(object sender, EventArgs e)
	{
		SearchFrame.IsVisible = false;
		_viewModel.SearchText = string.Empty;
		SearchEntry.Unfocus();
	}

	private async void OnMenuTapped(object sender, EventArgs e)
	{
		string action = await DisplayActionSheet("Menu", "Cancel", null, "Settings", "About");
		
		switch (action)
		{
			case "Settings":
				await DisplayAlert("Settings", "Settings functionality coming soon!", "OK");
				break;
			case "About":
				await DisplayAlert("About", "CashBook - Personal Finance Manager\nVersion 1.0", "OK");
				break;
		}
	}
}

