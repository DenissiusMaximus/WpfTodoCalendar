using System.ComponentModel.DataAnnotations;

namespace Calendar;

public class Event
{
    [Key]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? Priority { get; set; }
    public string? Type { get; set; }

}