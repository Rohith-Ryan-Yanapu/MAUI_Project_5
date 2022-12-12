using MAUI_Project_5.Views;
namespace MAUI_Project_5;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        Routing.RegisterRoute(nameof(AccountDetails), typeof(AccountDetails));
    }
}
