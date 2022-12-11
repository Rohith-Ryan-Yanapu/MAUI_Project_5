using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MAUI_Project_5.ViewModels;

public partial class AccountsViewModel : INotifyPropertyChanged
{
    public Action DisplayInvalidLoginPrompt;
    public event PropertyChangedEventHandler PropertyChanged;

    private string _email;
    private string _password;

    public string Email
    {
        get => _email;
        set
        {
            if (_email != value)
            {
                _email = value;
                OnPropertyChanged(); // reports this property
            }
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged(); // reports this property
            }
        }
    }
    public ICommand SubmitCommand { protected set; get; }
    public AccountsViewModel()
    {
        SubmitCommand = new Command(OnSubmit);
    }

    async public void OnSubmit()
    {
        if (_email != "demo@gmail.com" || _password != "secret")
        {
            DisplayInvalidLoginPrompt();
        }
        else
        {
            await Shell.Current.GoToAsync($"//AccountsList");
        }
    }

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}