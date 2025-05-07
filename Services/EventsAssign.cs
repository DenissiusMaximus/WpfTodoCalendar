using System.ComponentModel;
using Calendar.Data;
using Calendar.Models;
using Calendar.Services;
using Calendar.ViewModels;

namespace Calendar;

public class EventsAssign : CalendarElementViewModel
{
    public virtual DateTime Date { get; set; }
    public ObservableCollection<DayEventViewModel>? Events { get; set; } = new();

    public EventsAssign()
    {
        EventRepository.EventAdded += OnEventAdded;
    }
    
    public virtual void OnEventAdded(object sender, DayEventViewModel dayEvent)
    {
        if (Date != null && dayEvent != null && Date.Date == dayEvent.Date.Date)
            AddSingleEvent(dayEvent);
    }
    
    public void AddSingleEvent(DayEventViewModel dayEvent)
    {
        Events.Add(dayEvent);
        
        if (dayEvent is DayEventViewModelINotifyPropertyChanged notifyEvent)
        {
            notifyEvent.PropertyChanged += DayEvent_PropertyChanged;
        }
    }
    
    protected virtual void DayEvent_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
    }
    
    public void AddEvents(ObservableCollection<DayEventViewModel> events)
    {
        if (Events == null)
        {
            Events = new ObservableCollection<DayEventViewModel>();
        }
        
        foreach (var dayEvent in events)
        {
            Events.Add(dayEvent);
        }
    }
    
    public void ClearEvents()
    {
        if (Events != null)
        {
            Events.Clear();
        }
    }

    public void RemoveEvent(DayEventViewModel dayEvent)
    {
        if (Events != null)
        {
            Events.Remove(dayEvent);
        }
    }
}