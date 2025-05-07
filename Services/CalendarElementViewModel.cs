namespace Calendar.Services;

public abstract class CalendarElementViewModel
{
    public ObservableCollection<DayViewModel> DaysVMList { get; set; } = new();
    public ObservableCollection<string> ViewDaysList { get; set; } = new();
    public static ObservableCollection<string> DaysOfWeekList = new();


    static CalendarElementViewModel()
    {
        for (int i = 1; i <= 7; i++)
        {
            DaysOfWeekList.Add(CalendarInfo.GetDayName(i).full);
        }
    }
}
