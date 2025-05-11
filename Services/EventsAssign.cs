using System.ComponentModel;

namespace Calendar;

public class EventsAssign : CalendarElementViewModel
{
    public virtual DateTime Date { get; set; }
    public ObservableCollection<DayEventViewModel>? Events { get; set; } = new();

    public EventsAssign()
    {
        EventRepository.EventAdded += OnEventAdded;
        EventRepository.EventUpdated += OnEventUpdated;
    }    
    public virtual void OnEventUpdated(object sender, DayEventViewModel dayEvent)
    {
        if (Events != null)
        {
            var existing = Events.FirstOrDefault(ev => ev.Id == dayEvent.Id);
            if (existing != null)
            {
                int index = Events.IndexOf(existing);
                Events.RemoveAt(index);
                Events.Insert(index, dayEvent);
            }
        }
    }

    public virtual void OnEventRemoved(object sender, DayEventViewModel dayEvent)
    {
        if (Events != null)
        {
            var existing = Events.FirstOrDefault(ev => ev.Id == dayEvent.Id);
            if (existing != null)
            {
                int index = Events.IndexOf(existing);
                Events.RemoveAt(index);
            }
        }
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