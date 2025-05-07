namespace Calendar;

public class MonthDayViewModel : DayViewModel
{
    public string DayColor { get; set; }
    
    public MonthDayViewModel(DateTime date) : base(date)
    {
        SetProperties(date);
    }
    
    public MonthDayViewModel(DateTime date, string dayColor) : base(date)
    {
        SetProperties(date);
        DayColor = dayColor;
    }
    
    private void SetProperties(DateTime date)
    {
        Date = date;
        
        FormattedDate = date.ToString("dd");
        FormattedShortDate = date.ToString("dd/MM");
        FormattedTime = date.ToString("HH:mm");

    }
    
}
