using System.ComponentModel.DataAnnotations;

namespace FilmProductionSystem.Models;

public class Equipment
{
    [Key]
    public Guid EquipmentId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public bool Availability { get; set; }
    public string Condition { get; set; }
}