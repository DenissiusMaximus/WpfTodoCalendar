using System.ComponentModel;
using Calendar.Services;

namespace Calendar.Models;

public class DayEventViewModel : Event
{
    public int Id { get; set; }
    public string FormattedTime { get; set; }
    public string FormattedDate { get; set; }
    public SolidColorBrush Color { get; set; }
    
    public DayEventViewModel(Event e)
    {
        this.Name = e.Name;
        this.Description = e.Description;
        this.Priority = e.Priority;
        this.Type = e.Type;
        this.Date = e.Date;
        this.Id = e.Id;
        
        FormattedDate = e.Date.ToString("dd.MM.yyyy");
        FormattedTime = e.Date.ToString("HH:mm");
            
        Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(CalendarInfo.ChooseRandomColor()));
    }
}