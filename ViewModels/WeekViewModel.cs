using Calendar.Services;

namespace Calendar.ViewModels;

public class WeekViewModel : CalendarElementViewModel
{
    public WeekViewModel()
    {
        FillDaysVMList();
    }
    
    private void FillDaysVMList()
    {
        DaysVMList.Clear();
        for (int i = 0; i <= 6; i++)
        {
            DaysVMList.Add(new WeekDayViewModel(CalendarInfo.ShowWeekFirstDay.AddDays(i)));
        }
    }
}