using FilmProductionSystem.DTOs;
using FilmProductionSystem.Models;

namespace FilmProductionSystem.Repositories;

public interface IScheduleRepository
{
    Task<Schedule> AddNewScheduleDetails(AddScheduleDTO dto, Guid filmId);
}