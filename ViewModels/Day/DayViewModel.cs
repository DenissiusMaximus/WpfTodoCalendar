namespace Calendar;

public class DayViewModel : EventsAssign
{
    public override DateTime Date { get; set; }
    public string FormattedDate { get; set; }
    public string FormattedShortDate { get; set; }
    public string FormattedTime { get; set; }
    public bool IsToday => Date.Date == DateTime.Now.Date;

    public DayViewModel(DateTime date)
    {
        Date = date;
        FormattedDate = date.ToString("dd.MM.yyyy");
        FormattedShortDate = date.ToString("dd/MM");
        FormattedTime = date.ToString("HH:mm");

        LoadEventsAsync();
    }

    public async Task LoadEventsAsync()
    {
        var rep = new EventRepository();
        var events = await rep.GetByDateAsync(Date);

        foreach (var e in events)
        {
            AddSingleEvent(new DayEventViewModel(e));
        }
    }
}