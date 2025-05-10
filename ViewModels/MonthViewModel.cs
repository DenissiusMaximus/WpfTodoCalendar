using Calendar.Services;

namespace Calendar.ViewModels;

public class MonthViewModel : CalendarElementViewModel
{
    public ObservableCollection<MonthDayViewModel> DaysVMList { get; set; } = new();
    private List<DateTime> DaysDatesList { get; set; }

    public MonthViewModel()
    {
        FillViewDaysList();
        FillDaysVMList();
    }
    private void FillDaysVMList()
    {
        DaysDatesList = CalendarInfo.GetDaysList();

        foreach (var i in DaysDatesList)
        {
            DaysVMList.Add(new MonthDayViewModel(i));
        }
    }
    
    private void FillViewDaysList()
    {
        var daysList = CalendarInfo.GetDaysList();
        
        foreach (var i in daysList)
        {
            ViewDaysList.Add(i.Day.ToString());
        }
    }
    
    
}