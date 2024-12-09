using FilmProductionSystem.DTOs;
using FilmProductionSystem.Models;

namespace FilmProductionSystem.Services.Interface;

public interface IFilmServices
{
    Film AddFilmsAsync(AddFilmDTO dto);
    
    Task<List<ViewFilmIdandNameDTO>> GetAllFilmIdAndName();
}