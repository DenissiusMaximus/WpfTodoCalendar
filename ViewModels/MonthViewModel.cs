using Calendar.Services;

namespace Calendar.ViewModels;

public class MonthViewModel : CalendarElementViewModel
{
    public ObservableCollection<MonthDayViewModel> DaysVMList { get; set; } = new();
    private List<(string color, DateTime day)> DaysDatesList { get; set; }

    public MonthViewModel()
    {
        FillViewDaysList();
        FillDaysVMList();
    }
    private void FillDaysVMList()
    {
        DaysDatesList = CalendarInfo.GetDaysList();

        foreach (var (k, v)in DaysDatesList)
        {
            DaysVMList.Add(new MonthDayViewModel(v, k));
        }
    }
    
    private void FillViewDaysList()
    {
        var daysList = CalendarInfo.GetDaysList();
        
        foreach (var (k, v) in daysList)
        {
            ViewDaysList.Add(v.Day.ToString());
        }
    }
    
    
}