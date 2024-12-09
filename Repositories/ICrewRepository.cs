using FilmProductionSystem.DTOs;
using FilmProductionSystem.Models;

namespace FilmProductionSystem.Repositories;

public interface ICrewRepository
{
    Task<Crew> AddCrewDetailsAsync(AddCrewDTO dto, Guid filmId);
}