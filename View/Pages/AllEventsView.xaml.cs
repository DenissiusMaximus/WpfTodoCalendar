namespace Calendar;

public partial class AllEventsView : Page, ICalendarEventsView<AllEventsViewModel>
{
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
        AllEventsViewModel.SelectedEvents.Clear();
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
}