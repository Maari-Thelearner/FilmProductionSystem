using FilmProductionSystem.Data;
using FilmProductionSystem.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FilmProductionSystem.Repositories;

public class Repository<T>: IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        this._context = context;
    }
    public async Task<T> AddAsync(T entity)
    {
        this._context.Set<T>().AddAsync(entity);
        await this._context.SaveChangesAsync();

        return entity;
    }

    public Task<List<ViewFilmIdandNameDTO>> GetIdAndName()
    {
        var data = this._context.Films.Select(f => new ViewFilmIdandNameDTO()
        {
            FilmId = f.FilmId,
            Title = f.Title
        }).ToListAsync();

        return data;
    }
}