using Calendar.Models;
using Calendar.Services;

namespace Calendar.Data;

public class EventRepository
{
    private readonly DbManager _dbManager;
    public static event EventHandler<DayEventViewModel> EventAdded;
    public static event EventHandler<DayEventViewModel> EventUpdated;
    
    public EventRepository(string dbPath = @"C:\Users\sloke\RiderProjects\WpfApp2\Calendar\Resources\DB\database.sqlite;")
    {
        _dbManager = new DbManager(dbPath);
    }
    
    public async Task DeleteEventAsync(Event e)
    {
        using var connection = _dbManager.GetConnection();
        await connection.OpenAsync();
        
        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Events WHERE Id = @id";
        command.Parameters.AddWithValue("@id", e.Id);
        
        await command.ExecuteNonQueryAsync();

        EventUpdated?.Invoke(this, new DayEventViewModel(e));
    }

    public async Task EditEventAsync(Event e)
    {
        using var connection = _dbManager.GetConnection();
        await connection.OpenAsync();
        
        var command = connection.CreateCommand();
        command.CommandText = "UPDATE Events SET Date = @date, Name = @name, Description = @description, Priority = @priority, Type = @type WHERE Id = @id";
        
        command.Parameters.AddWithValue("@id", e.Id);
        command.Parameters.AddWithValue("@date", e.Date);
        command.Parameters.AddWithValue("@name", e.Name);
        command.Parameters.AddWithValue("@description", e.Description ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@priority", e.Priority ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@type", e.Type ?? (object)DBNull.Value);
        
        await command.ExecuteNonQueryAsync();
        
        EventUpdated?.Invoke(this, new DayEventViewModel(e));
    }
    
    public async Task<Event> GetEventByIdAsync(int id)
    {
        string commandText = $"SELECT * FROM Events WHERE Id = {id}";
        
        var events = await GetByCommandAsync(commandText);
        
        return events.Count > 0 ? events[0] : null;
    }

    public async Task<List<Event>> GetAllEventsAsync()
    {
        string commdandText = "SELECT * FROM Events";
        
        return await GetByCommandAsync(commdandText);
    }
    
    public async Task<List<Event>> GetByDateAsync(DateTime date)
    {
        string commandText = $"SELECT * FROM Events WHERE strftime('%Y-%m-%d', Date) = '{date:yyyy-MM-dd}'";

        
        return await GetByCommandAsync(commandText);
    }

    public async Task AddEventAsync(Event e)
    {
        using var connection = _dbManager.GetConnection();
        await connection.OpenAsync();
        
        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Events (Date, Name, Description, Priority, Type) VALUES (@date, @name, @description, @priority, @type)";
        
        command.Parameters.AddWithValue("@date", e.Date);
        command.Parameters.AddWithValue("@name", e.Name);
        command.Parameters.AddWithValue("@description", e.Description ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@priority", e.Priority ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@type", e.Type ?? (object)DBNull.Value);
        
        await command.ExecuteNonQueryAsync();
        
        command.CommandText = "SELECT last_insert_rowid();";
        e.Id = Convert.ToInt32(await command.ExecuteScalarAsync());
        
        EventAdded?.Invoke(this, new DayEventViewModel(e));
    }

    public async Task<List<Event>> GetByCommandAsync(string commandText)
    {
        using var connection = _dbManager.GetConnection();
        await connection.OpenAsync();
        
        var command = connection.CreateCommand();
        command.CommandText = commandText;
        
        await using var reader = await command.ExecuteReaderAsync();
        
        var events = new List<Event>();

        while (await reader.ReadAsync())
        {
            var eventItem = new Event
            {
                Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                Date = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1),
                Name = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                Description = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                Priority = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                Type = reader.IsDBNull(5) ? null : reader.GetString(5)
            };
            
            events.Add(eventItem);
        }

        return events;
    }
}