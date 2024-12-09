using System.ComponentModel.DataAnnotations;

namespace FilmProductionSystem.Models;

public class Film
{
    [Key]
    public Guid FilmId { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Status { get; set; }
    
    
    //one - many relationship
    public ICollection<Crew> Crews { get; set; }
    public ICollection<Schedule> Schedules { get; set; }
}