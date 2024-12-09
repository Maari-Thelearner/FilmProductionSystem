using FilmProductionSystem.Data;
using FilmProductionSystem.DTOs;
using FilmProductionSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmProductionSystem.Repositories;

public class CrewRepository: ICrewRepository
{
    private readonly ApplicationDbContext _context;

    public CrewRepository(ApplicationDbContext context)
    {
        this._context = context;
    }

    private async Task SaveDBChanges()
    {
        await this._context.SaveChangesAsync();
    }


    public async Task<Crew> AddCrewDetailsAsync(AddCrewDTO dto, Guid filmId)
    {
        Film film = await this._context.Films.Where(f => f.FilmId == filmId).FirstOrDefaultAsync();
        if (film != null)
        {
            var crew = new Crew()
            {
                CrewId = new Guid(),
                Name = dto.Name,
                ContactInfo = dto.ContactInfo,
                Availability = dto.Availability,
                Role = dto.Role,
                FilmId = filmId,
                film = film
            };
            await this._context.Crews.AddAsync(crew);
            await this.SaveDBChanges();

            return crew;
        }

        return null;
    }
}