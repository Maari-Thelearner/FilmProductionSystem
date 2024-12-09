using FilmProductionSystem.DTOs;
using FilmProductionSystem.Models;

namespace FilmProductionSystem.Repositories;

public interface IFilmsRepository
{
     Task AddFilmsAsync(Film film);
     Task<List<ViewFilmIdandNameDTO>> GetAllFilmIdAndName();
}