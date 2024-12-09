using FilmProductionSystem.DTOs;

namespace FilmProductionSystem.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<List<ViewFilmIdandNameDTO>> GetIdAndName();
}