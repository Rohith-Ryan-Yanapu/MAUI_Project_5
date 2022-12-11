using MAUI_Project_5.ViewModels;

namespace MAUI_Project_5.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(AccountsViewModel VM)
    {
        InitializeComponent();
        BindingContext = VM;
        VM.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
    }
}