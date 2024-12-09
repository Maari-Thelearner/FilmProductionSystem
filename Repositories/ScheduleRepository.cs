using FilmProductionSystem.Data;
using FilmProductionSystem.DTOs;
using FilmProductionSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmProductionSystem.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly ApplicationDbContext _context;

    public ScheduleRepository(ApplicationDbContext context)
    {
        this._context = context;
    }

    private async Task SaveDBChanges()
    {
        await this._context.SaveChangesAsync();
    }

    public async Task<Schedule> AddNewScheduleDetails(AddScheduleDTO dto, Guid filmId)
    {
        Film filmData = await this._context.Films.Where(f => f.FilmId == filmId).FirstOrDefaultAsync();
        Schedule schedule = new Schedule()
        {
            ScheduleId = new Guid(),
            SceneDescription = dto.SceneDescription,
            Location = dto.Location,
            ScheduledDate = dto.ScheduledDate,
            FilmId = filmId,
            film = filmData
        };

        await this._context.Schedules.AddAsync(schedule);

        await this.SaveDBChanges();

        return schedule;
    }
}