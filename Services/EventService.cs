using Calendar.Data;
using Calendar.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Services;

public class EventService
{
    public async Task<List<Event>> GetAllEventsAsync()
    {
        using var context = new ApplicationDbContext();
        return await context.Events.ToListAsync();
    }

    public async Task<Event> GetEventByIdAsync(int id)
    {
        using var context = new ApplicationDbContext();
        return await context.Events.FirstOrDefaultAsync(x => x.Id == id);
    }
    

    public async Task AddEventAsync(Event newEvent)
    {
        using var context = new ApplicationDbContext();
        await context.Events.AddAsync(newEvent);
        await context.SaveChangesAsync();
    }

    public async Task UpdateEventAsync(Event updatedEvent)
    {
        using var context = new ApplicationDbContext();
        context.Events.Update(updatedEvent);
        await context.SaveChangesAsync();
    }

    public async Task DeleteEventAsync(int id)
    {
        using var context = new ApplicationDbContext();
        var eventToDelete = await context.Events.FirstOrDefaultAsync(x => x.Id == id);
        if (eventToDelete != null)
        {
            context.Events.Remove(eventToDelete);
            await context.SaveChangesAsync();
        }
    }
}