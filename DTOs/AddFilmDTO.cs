namespace FilmProductionSystem.DTOs;

public class AddFilmDTO
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Status { get; set; }
}