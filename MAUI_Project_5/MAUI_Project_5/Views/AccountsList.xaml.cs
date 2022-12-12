using System.Collections.ObjectModel;
using PrivatePocketSafe.Data;
using PrivatePocketSafe.Models;

namespace PrivatePocketSafe.Views;

public partial class AccountsList : ContentPage
{
    UNPItemDatabase database;
    public ObservableCollection<UNPItem> Items { get; set; } = new();
    public AccountsList(UNPItemDatabase Database)
	{
		InitializeComponent();
        database = Database;
        BindingContext = this;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var items = await database.GetItemsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            foreach (var item in items)
                Items.Add(item);
        });
    }
    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AccountDetails), true, new Dictionary<string, object>
        {
            ["Item"] = new UNPItem()
        });
    }

    private async void  CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not UNPItem item)
            return;

        await Shell.Current.GoToAsync(nameof(AccountDetails), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
    }
}

