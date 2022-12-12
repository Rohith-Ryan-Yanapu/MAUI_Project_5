using MAUI_Project_5.ViewModels;
using MAUI_Project_5.Views;

namespace MAUI_Project_5;

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

        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<AccountsList>();
        builder.Services.AddTransient<AccountDetails>();

        builder.Services.AddSingleton<AccountsViewModel>();

        return builder.Build();
	}
}
