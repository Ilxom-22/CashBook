using Microsoft.Extensions.Logging;
using CashBook.Mobile.Services;
using CashBook.Mobile.ViewModels;

namespace CashBook.Mobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Register services
		builder.Services.AddHttpClient<ICashbookService, CashbookService>(client =>
		{
			client.Timeout = TimeSpan.FromSeconds(10); // 10 second timeout for quick error feedback
		});
		
		// Register ViewModels
		builder.Services.AddTransient<MainPageViewModel>();
		
		// Register Pages
		builder.Services.AddTransient<MainPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
