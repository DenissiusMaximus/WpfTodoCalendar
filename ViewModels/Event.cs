using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calendar.Models;

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