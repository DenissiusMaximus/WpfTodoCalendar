namespace Calendar;

public partial class AllEventsView : Page, ICalendarEventsView<AllEventsViewModel>
{
    public static event EventHandler<int>? EventSelectedEvent;
    public AllEventsViewModel ViewModel { get; set; } = new();
    public ICalendarEventsView<AllEventsViewModel> Instance { get; set; }
    
    
    public AllEventsView()
    {
        SetDataContext();
        InitializeComponent();
        Instance = this;
    }
    
    public void SetDataContext()
    {
        DataContext = null;
        DataContext = ViewModel;
    }
    public void ClearSelected_ButtonClick(object sender, RoutedEventArgs e)
    {
        if (AllEventsViewModel.SelectedEvents != null)
        {
            foreach (var selectedEvent in AllEventsViewModel.SelectedEvents.ToList())
            {
                selectedEvent.IsSelected = false;
            }
        }
    }



    public void DeleteSelected_ButtonClick(object sender, RoutedEventArgs e)
    {
        if (AllEventsViewModel.SelectedEvents.ToList().Count() == 0)
            return;

        var result = MessageBox.Show("Delete selected events?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            DeleteSelectedEvents();
        }

    }

    private void DeleteSelectedEvents()
    {
        var eventsToDelete = AllEventsViewModel.SelectedEvents.ToList();

        foreach (var selectedEvent in eventsToDelete)
        {
            var rep = new EventRepository();
            rep.DeleteEventAsync(selectedEvent);

            AllEventsViewModel.SelectedEvents.Remove(selectedEvent);
        }
    }

    private void EventButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is int id)
        {
            Instance.OpenEditPage();
            EventSelectedEvent?.Invoke(this, id);
        }

    }
}