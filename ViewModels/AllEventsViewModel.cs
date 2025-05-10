using System.ComponentModel;
using Calendar.Data;

namespace Calendar.ViewModels;

public class AllEventsViewModel : EventsAssign, INotifyPropertyChanged
{
    public static ObservableCollection<DayEventViewModelINotifyPropertyChanged>? SelectedEvents { get; set; } = new();
    
    
    public AllEventsViewModel()
    {
        LoadEventsAsync();
    }

    public override void OnEventAdded(object sender, DayEventViewModel dayEvent)
    {
        if (Date != null && dayEvent != null)
            AddSingleEvent(dayEvent);
    }
    
    public async Task LoadEventsAsync()
    {
        var rep = new EventRepository();
        var events = await rep.GetAllEventsAsync();
        
        foreach (var e in events)
        {
            if(!Events.Contains(e))
                AddSingleEvent(new DayEventViewModelINotifyPropertyChanged(e));
        }
        
    }
    
    protected override void DayEvent_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(DayEventViewModelINotifyPropertyChanged.IsSelected))
        {
            var dayEvent = sender as DayEventViewModelINotifyPropertyChanged;
            if (dayEvent != null)
            {
                if (dayEvent.IsSelected && !SelectedEvents.Contains(dayEvent))
                {
                    SelectedEvents.Add(dayEvent);
                }
                else if (!dayEvent.IsSelected && SelectedEvents.Contains(dayEvent))
                {
                    SelectedEvents.Remove(dayEvent);
                }
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}