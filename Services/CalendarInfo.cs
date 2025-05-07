namespace Calendar.Services;

public static class CalendarInfo
{
    public static DateTime CurrentDate { get; private set; }
    public static int ShowYear => _showDate.Year;
    public static int ShowMonth => _showDate.Month;
    public static DateTime ShowWeekFirstDay { get; private set; }
    public static string ShowMonthString { get; private set; }
    public static DateTime calendarDay { get; private set; }

    private static DateTime _showDate;

    static CalendarInfo()
    {
        SetDefaultDate();
        GetCalendarDay();

        ShowMonthString = GetMonthName(_showDate.Month);
    }

    public static string ChooseRandomColor()
    {
        var random = new Random();
        string[] colors = { "fbddd4", "98b0fc", "a8dfe6", "ebedac", "e0b5c7", "e2bdc1", "ddede5", "98b0fc" };

        var randLen = random.Next(colors.Length - 1);

        return $"#{colors[randLen]}";
    }

    public static void ChangeShowWeek(DateChangeDirection d)
    {
        ShowWeekFirstDay = ShowWeekFirstDay.AddDays(7 * (int)d);
    }

    public static DateTime _setShowWeek()
    {
        int dayOfWeekNumber = (int)CurrentDate.DayOfWeek;

        if (dayOfWeekNumber == 0)
            dayOfWeekNumber = 7;

        var firstDayOfWeekDate = CurrentDate.AddDays(-dayOfWeekNumber + 1);

        return firstDayOfWeekDate;
    }


    public static void SetDefaultDate()
    {
        CurrentDate = DateTime.Today;
        _showDate = new DateTime(CurrentDate.Year, CurrentDate.Month, CurrentDate.Day);
        ShowWeekFirstDay = _setShowWeek();
    }

    public static void GetCalendarDay()
    {
        var firstDayOfCurrMonth = new DateTime(ShowYear, _showDate.Month, 1).DayOfWeek;
        int firstDayOfCurrWeekNumber = (int)firstDayOfCurrMonth;

        if (firstDayOfCurrWeekNumber == 0)
            firstDayOfCurrWeekNumber = 7;

        var lastDayOfCurrMonthNumber = DateTime.DaysInMonth(ShowYear, _showDate.Month);

        calendarDay = new DateTime(ShowYear, _showDate.Month, 1).AddDays(-firstDayOfCurrWeekNumber + 1);
    }
    public static List<(string color, DateTime day)> GetDaysList()
    {
        var firstDayOfCurrMonth = new DateTime(ShowYear, _showDate.Month, 1).DayOfWeek;
        int firstDayOfCurrWeekNumber = (int)firstDayOfCurrMonth;
        string color;

        if (firstDayOfCurrWeekNumber == 0)
            firstDayOfCurrWeekNumber = 7;

        var lastDayOfCurrMonthNumber = DateTime.DaysInMonth(ShowYear, _showDate.Month);

        var cDay = new DateTime(ShowYear, _showDate.Month, 1).AddDays(-firstDayOfCurrWeekNumber + 1);
        
        List<(string color, DateTime day)> days = new();
        
        for (int i = 0; i < 42; i++)
        {
            if(cDay.AddDays(i).Month == ShowMonth)
                color = "#000000";
            else
                color = "#a3a3a3";
            
            days.Add((color, cDay.AddDays(i)));
        }
        
        
        return days;
    }

    public static void ChangeShowYear(DateChangeDirection d)
    {
        _showDate = _showDate.AddYears((int)d);

        GetCalendarDay();
    }

    public static void ChangeShowMonth(DateChangeDirection d)
    {
        _showDate = _showDate.AddMonths((int)d);

        GetCalendarDay();

        ShowMonthString = GetMonthName(_showDate.Month);
    }
    
    public static List<(string full, string w)> GetDayOfWekkDaysKist()
    {
        var daysList = new List<(string full, string w)>();
        
        for (int i = 0; i < 7; i++)
        {
            var day = GetDayName(i + 1);
            daysList.Add(day);
        }
        
        return daysList;
    }

    public static (string full, string w) GetDayName(int dayNumber)
    {
        return dayNumber switch
        {
            1 => ("Понеділок", "Пн"),
            2 => ("Вівторок", "Вт"),
            3 => ("Середа", "Ср"),
            4 => ("Четвер", "Чт"),
            5 => ("П`ятниця", "Пт"),
            6 => ("Субота", "Сб"),
            7 => ("Неділя", "Нд"),
            0 => ("Неділя", "Нд"),

            _ => throw new ArgumentOutOfRangeException(nameof(dayNumber), dayNumber, null)
        };
    }
    

    public static string GetMonthName(int monthNumber)
    {
        return monthNumber switch
        {
            1 => "Січень",
            2 => "Лютий",
            3 => "Березень",
            4 => "Квітень",
            5 => "Травень",
            6 => "Червень",
            7 => "Липень",
            8 => "Серпень",
            9 => "Вересень",
            10 => "Жовтень",
            11 => "Листопад",
            12 => "Грудень",
            _ => throw new ArgumentOutOfRangeException(nameof(monthNumber), monthNumber, null)
        };
    }
}