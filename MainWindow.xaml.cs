namespace Calendar;

public partial class MainWindow : Window
{
    private static EventManager _eventManagerView = new();
    private static MonthView _monthView = new();
    private static WeekView _weekView = new();
    private AllEventsView _allEventsView = new();
    
    public MainWindow()
    {
        InitializeComponent();

        MainContentFrame.Navigate(_monthView);
    }

    private void AllMonthCalendarView_Click(object sender, RoutedEventArgs e)
    {
        MainContentFrame.Navigate(_monthView);
    }

    private void SingleWeekCalendarView_Click(object sender, RoutedEventArgs e)
    {
        MainContentFrame.Navigate(_weekView);
    }

    private void AllEventsListView_Click(object sender, RoutedEventArgs e)
    {
        MainContentFrame.Navigate(_allEventsView);
    }
    
    private void AddEventView_Click(object sender, RoutedEventArgs e)
    {
        if (ManageContentFrame.Content is EventManager)
            CloseEventManagementView();
        else
            ManageContentFrame.Navigate(_eventManagerView);

    }
    public void CloseEventManagementView()
    {
        ManageContentFrame.Content = null;
    }
}