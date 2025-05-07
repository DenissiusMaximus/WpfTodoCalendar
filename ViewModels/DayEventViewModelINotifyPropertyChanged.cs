using System.ComponentModel;
using Calendar.Models;

namespace global::System.Windows.Controls.Calendar.ViewModels;

public class DayEventViewModelINotifyPropertyChanged : DayEventViewModel, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public DayEventViewModelINotifyPropertyChanged(Event e) : base(e)
    {
    }
    

    private bool _isSelected;
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            OnPropertyChanged(nameof(IsSelected));
        }
    }
    
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}