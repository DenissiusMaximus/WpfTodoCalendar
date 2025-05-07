using Calendar.Models;

namespace Calendar.Services;

public static class EventsCash
{
    private static Dictionary <DateTime, DayViewModel> events = new();
    private static ObservableCollection<DayEventViewModel> AllEventsList = new();

    public static void AddAllEvents()
    {
        var service = new EventService();
        var events = service.GetAllEventsAsync().Result;
        
        foreach (var e in events)
        {
            AllEventsList.Add(new DayEventViewModel(e));
        }
    }
    
    public static ObservableCollection<DayEventViewModel> GetAllEvents()
    {
        if (AllEventsList.Count == 0)
        {
            AddAllEvents();
        }
        
        return AllEventsList;
    }
    
    public static void GetEvents(DateTime date, out DayViewModel? cahsEvent)
    {
        if (events.ContainsKey(date))
        {
            cahsEvent = events[date];
        }
        else
        {
            cahsEvent = null;
        }
    }
    
    public static void AddEvent(DateTime date, DayViewModel? dayViewModel)
    {
        events[date] = dayViewModel;
    }
}