namespace Calendar;

public interface ICalendarEventsView<T> where T : CalendarElementViewModel, new()
{
    public static event EventHandler<int> EventSelectedEvent;
    public T ViewModel { get; set; }
    public ICalendarEventsView<T> Instance { get; set; }
    public void SetDataContext();

    public void OnStep(object sender, Action<DateChangeDirection> StepHandler)
    {
        FrameworkElement? element = sender as FrameworkElement;

        if (element?.Tag is null)
            throw new NullReferenceException("Tag is null");

        var tag = element.Tag.ToString();
        var direction = tag == "-1" ? DateChangeDirection.Previous : DateChangeDirection.Next;

        StepHandler.Invoke(direction);

        ViewModel = new T();
        SetDataContext();
    }

    public void OpenEditPage()
    {
        var mainWindow = Application.Current.MainWindow as MainWindow;

        if (mainWindow != null)
            if (mainWindow.ManageContentFrame.Content is not EditEventUserControl)
                mainWindow.OpenEventManagementEditView();

    }
}