using Calendar.Services;
using Calendar.ViewModels;

namespace Calendar;

public partial class MonthView : Page, ICalendarEventsView<MonthViewModel>
{
    public static event EventHandler<int> EventSelectedEvent;
    public MonthViewModel ViewModel { get; set; } = new();
    public ICalendarEventsView<MonthViewModel> Instance { get; set; }

    public MonthView()
    {
        Instance = this;
        InitializeComponent();

        SetDataContext();
    }
    
    public void SetDataContext()
    {
        SetCorrectDatesText();
        
        DataContext = null;
        DataContext = ViewModel;
    }

    private void SetCorrectDatesText()
    {
        MonthTextblock.Text = CalendarInfo.ShowMonthString;
        YearTextblock.Text = CalendarInfo.ShowYear.ToString();
    }

    private void ChangeMonthButton_Click(object sender, RoutedEventArgs e)
    {
        Instance.OnStep(sender, CalendarInfo.ChangeShowMonth);

        SetCorrectDatesText();
    }

    private void ChangeYearButton_Click(object sender, RoutedEventArgs e)
    {
        Instance.OnStep(sender, CalendarInfo.ChangeShowYear);

        SetCorrectDatesText();
    }

    private void EventButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is int id)
        {
            EventSelectedEvent?.Invoke(this, id);
        }
        
    }
}