using System.Windows.Media.Converters;

namespace Calendar;

public class MonthDayViewModel : DayViewModel
{
    public string BorderColor { get; set; }
    public string DayColor { get; set; }
   
    
    public MonthDayViewModel(DateTime date, string dayColor) : base(date)
    {
        SetProperties(date, dayColor);
    }
    
    private void SetProperties(DateTime date, string dayColor)
    {
        Date = date;
        
        FormattedDate = date.ToString("dd");
        FormattedShortDate = date.ToString("dd/MM");
        FormattedTime = date.ToString("HH:mm");
        
        DayColor = dayColor;

        if (Date.Date == DateTime.Now.Date)
            BorderColor = "#4772fa";
        else
            BorderColor = "Transparent";
    }
    
}
