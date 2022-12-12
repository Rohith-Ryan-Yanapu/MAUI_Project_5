using SQLite;

namespace PrivatePocketSafe.Models;

public class UNPItem
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Title { get; set; }
    public string UserID { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
}
