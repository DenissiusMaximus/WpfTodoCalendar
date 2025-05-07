using Calendar.Data;
using Calendar.Models;

namespace Calendar;

public partial class AddEventUserControl : UserControl
{
    private static string EventName;
    private static string Description;
    private static int PriorityValue;
    private static DateTime EventDateTime;
    
    public AddEventUserControl()
    {
        InitializeComponent();
    }
    
    private void ResetButton_OnClick(object sender, RoutedEventArgs e)
    {
        NameTextBlock.Text = "";
        DescriptionTextBlock.Text = "";
        HoursTextBox.Text = "12";
        MinutesTextBox.Text = "30";
        EventDatePicker.SelectedDate = DateTime.Now.Date;
        PrioritySlider.Value = 0;
    }

    private void CloseButton_OnClick(object sender, RoutedEventArgs e)
    {
        var mainWindow = Application.Current.MainWindow as MainWindow;
    
        if (mainWindow != null)
        {
            mainWindow.CloseEventManagementView();
        }

    }

    private async void OkButton_OnClick(object sender, RoutedEventArgs e)
    {
        EventName = NameTextBlock.Text;
        if (EventName == "")
        {
            MessageBox.Show("Please enter a name for the event");
            return;
        }
        
        DateTime? eventDate = EventDatePicker.SelectedDate ?? DateTime.Now.Date;
        var eventTimeHours = HoursTextBox.Text;
        var eventTimeMinutes = MinutesTextBox.Text;
        
        
        try
        {
            int hours;
            int.TryParse(HoursTextBox.Text, out hours);

            if (hours >= 0 && hours <= 24)
                hours = 12;

            int minutes;
            int.TryParse(MinutesTextBox.Text, out minutes);
            
            if (minutes >= 0 && minutes <= 59)
                minutes = 30;
    
            EventDateTime = eventDate.Value.Date.AddHours(hours).AddMinutes(minutes);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Invalid date or time format: {ex.Message}");
            return;
        }
        
        Description = DescriptionTextBlock.Text;
        
        var priority = PrioritySlider.Value;
        PriorityValue = (int)priority;

        try
        {
            Event newEvent = new Event
            {
                Name = EventName,
                Date = EventDateTime,
                Description = Description,
                Priority = PriorityValue,
                Type = null
            };
            
            var rep = new EventRepository();
            await rep.AddEventAsync(newEvent);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Invalid event: \n{ex.Message}");
        }
        

        MessageBox.Show("Event added successfully!");
    }
}