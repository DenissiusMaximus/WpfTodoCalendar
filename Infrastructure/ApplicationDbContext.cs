using Microsoft.EntityFrameworkCore;

namespace Calendar;

public class ApplicationDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public string DbPath { get; }

    public ApplicationDbContext()
    {
        DbPath = @"C:\Users\sloke\RiderProjects\WpfApp2\Calendar\Resources\DB\database.sqlite";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}