namespace Calendar;

public partial class EventManager : Page
{
    public EventManager()
    {
        InitializeComponent();

        EventContentHost.Content = new AddEventUserControl();
    }

    private void AddEventButton_OnClick(object sender, RoutedEventArgs e)
    {
        EventContentHost.Content = new AddEventUserControl();
    }

    private void EditEventButton_OnClick(object sender, RoutedEventArgs e)
    {
        EventContentHost.Content = new EditEventUserControl();
    }
}