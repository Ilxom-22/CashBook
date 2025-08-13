using CashBook.Mobile.ViewModels;

namespace CashBook.Mobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}
}
