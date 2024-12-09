using FilmProductionSystem.Data;
using FilmProductionSystem.DTOs;
using FilmProductionSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmProductionSystem.Repositories;

public class FilmsRepository : IFilmsRepository
{
    private readonly ApplicationDbContext _context;
    public FilmsRepository(ApplicationDbContext context)
    {
        this._context = context;
    }
    public async Task AddFilmsAsync(Film film)
    {
        await this._context.Films.AddAsync(film);
        await this._context.SaveChangesAsync();
    }

    public async Task<List<ViewFilmIdandNameDTO>> GetAllFilmIdAndName()
    {
        var data = await this._context.Films.Select(f => new ViewFilmIdandNameDTO()
        {
            FilmId = f.FilmId,
            Title = f.Title
        }).ToListAsync();

        return data;
    }
}