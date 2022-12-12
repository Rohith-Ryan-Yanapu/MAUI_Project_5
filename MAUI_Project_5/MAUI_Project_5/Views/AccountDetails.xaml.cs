using PrivatePocketSafe.Data;
using PrivatePocketSafe.Models;

namespace PrivatePocketSafe.Views;

[QueryProperty("Item", "Item")]
public partial class AccountDetails : ContentPage
{
	public UNPItem Item
	{
		get => BindingContext as UNPItem;
		set => BindingContext = value;
	}
    UNPItemDatabase database;
    public AccountDetails(UNPItemDatabase Database)
    {
        InitializeComponent();
        database = Database;
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Title))
        {
            await DisplayAlert("Title Required", "Please enter a title for the Account.", "OK");
            return;
        }

        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.ID == 0)
            return;
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}