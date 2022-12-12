using PrivatePocketSafe.Views;
using PrivatePocketSafe.Data;
using PrivatePocketSafe.ViewModels;

namespace PrivatePocketSafe;

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
