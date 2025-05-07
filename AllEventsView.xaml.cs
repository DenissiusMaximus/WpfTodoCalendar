using Calendar.Services;
using Calendar.ViewModels;

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
}