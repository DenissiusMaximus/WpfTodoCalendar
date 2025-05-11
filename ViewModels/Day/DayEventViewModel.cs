
namespace Calendar;

public class DayEventViewModel : Event
{
    public int Id { get; set; }
    public string FormattedTime { get; set; }
    public string FormattedDate { get; set; }
    public SolidColorBrush Color { get; set; }

    public DayEventViewModel(Event e)
    {
        Name = e.Name;
        Description = e.Description;
        Priority = e.Priority;
        Type = e.Type;
        Date = e.Date;
        Id = e.Id;

        FormattedDate = e.Date.ToString("dd.MM.yyyy");
        FormattedTime = e.Date.ToString("HH:mm");

        Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(CalendarInfo.ChooseRandomColor()));
    }
}