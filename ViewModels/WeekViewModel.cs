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
        for(int i = 0; i <= 6; i++)
        {
            DaysVMList.Add(new DayViewModel(CalendarInfo.ShowWeekFirstDay.AddDays(i)));
        }
    }
    

}