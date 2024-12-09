using System.ComponentModel.DataAnnotations;

namespace FilmProductionSystem.Models;

public class Crew
{
    [Key]
    public Guid CrewId { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public string ContactInfo { get; set; }
    public bool Availability { get; set; }
    
    //one - Many relationships
    public Guid FilmId { get; set; }
    public Film film { get; set; }
}