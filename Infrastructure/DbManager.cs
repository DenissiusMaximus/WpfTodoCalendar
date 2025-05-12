using Microsoft.Data.Sqlite;

namespace Calendar;

public class DbManager
{
// "Data Source=C:\\Users\\sloke\\RiderProjects\\WpfApp2\\Calendar\\Resources\\DB\\database.sqlite;"
    private string ConnectionString { get; set; }
    
    public DbManager(string path)
    {
        ConnectionString = $"Data Source={path};";
    }
    
    public SqliteConnection GetConnection()
    {
        return new SqliteConnection(ConnectionString);
    }

}