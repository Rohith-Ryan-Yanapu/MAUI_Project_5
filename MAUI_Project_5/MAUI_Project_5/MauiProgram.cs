using MAUI_Project_5.Views;
using MAUI_Project_5.Data;
using MAUI_Project_5.ViewModels;

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
        builder.Services.AddSingleton<UNPItemDatabase>();

        return builder.Build();
	}
}
