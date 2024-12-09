using System.ComponentModel.DataAnnotations;

namespace FilmProductionSystem.Models;

public class Schedule
{
    [Key]
    public Guid ScheduleId { get; set; }
    public string SceneDescription { get; set; }
    public DateTime ScheduledDate { get; set; }
    public string Location { get; set; }
    
    //one - many relationships
    public Guid FilmId { get; set; }
    public Film film { get; set; }
}