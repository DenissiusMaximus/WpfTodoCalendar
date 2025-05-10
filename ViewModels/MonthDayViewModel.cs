using System.Windows.Media.Converters;

namespace Calendar;

public class MonthDayViewModel : DayViewModel
{
     public bool IsCurrentMonth => Date.Month == CalendarInfo.ShowMonth;

    public MonthDayViewModel(DateTime date) : base(date)
    {
    }    
}
