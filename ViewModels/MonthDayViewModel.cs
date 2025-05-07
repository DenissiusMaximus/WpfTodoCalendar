namespace WpfApp2;

public class MonthDayViewModel : DayViewModel
{
    public MonthDayViewModel(DateTime date) : base(date)
    {
        Date = date;
        
        FormattedDate = date.ToString("dd");
        FormattedShortDate = date.ToString("dd/MM");
        FormattedTime = date.ToString("HH:mm");

        LoadEventsAsync();
    }
    
    public string DayColor { get; set; }
}