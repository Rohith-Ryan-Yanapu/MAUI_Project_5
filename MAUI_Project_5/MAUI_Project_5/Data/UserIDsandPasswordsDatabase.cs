using SQLite;
using PrivatePocketSafe.Models;

namespace PrivatePocketSafe.Data;

public class UNPItemDatabase
{
    SQLiteAsyncConnection Database;
    public UNPItemDatabase()
    {
    }
    async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(DatabaseLocation.DatabasePath, DatabaseLocation.Flags);
        await Database.CreateTableAsync<UNPItem>();
    }

    public async Task<List<UNPItem>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<UNPItem>().ToListAsync();
    }
    public async Task<UNPItem> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<UNPItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }
    public async Task<int> SaveItemAsync(UNPItem item)
    {
        await Init();
        if (item.ID != 0)
        {
            return await Database.UpdateAsync(item);
        }
        else
        {
            return await Database.InsertAsync(item);
        }
    }
    public async Task<int> DeleteItemAsync(UNPItem item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }
}