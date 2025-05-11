namespace Calendar;

public partial class WeekView : Page, ICalendarEventsView<WeekViewModel>
{
    public static event EventHandler<int> EventSelectedEvent;
    public WeekViewModel ViewModel { get; set; } = new();
    public ICalendarEventsView<WeekViewModel> Instance { get; set; }
    
    public WeekView()
    {
        Instance = this;
        SetDataContext();
        
        InitializeComponent();
    }
    
    public void SetDataContext()
    {
        DataContext = null;
        DataContext = ViewModel;
    }

    private void ChangeMonth_Click(object sender, RoutedEventArgs e)
        => Instance.OnStep(sender, CalendarInfo.ChangeShowWeek);
    
    private void EventButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is int id)
        {
            EventSelectedEvent?.Invoke(this, id);
        }
        
    }
}