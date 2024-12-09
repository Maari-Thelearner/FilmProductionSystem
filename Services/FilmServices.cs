using FilmProductionSystem.DTOs;
using FilmProductionSystem.Models;
using FilmProductionSystem.Repositories;
using FilmProductionSystem.Services.Interface;

namespace FilmProductionSystem.Services;

public class FilmServices: IFilmServices
{
    private readonly IRepository<Film> _repository;
    private IFilmServices _filmServicesImplementation;

    public FilmServices(IRepository<Film> repository)
    {
        this._repository = repository;
    }

    public Film AddFilmsAsync(AddFilmDTO dto)
    {
        var film = new Film()
        {
            FilmId = new Guid(),
            Title = dto.Title,
            Genre = dto.Genre,
            ReleaseDate = dto.ReleaseDate,
            Status = dto.Status
        };

        this._repository.AddAsync(film);

        return film;
    }

    public Task<List<ViewFilmIdandNameDTO>> GetAllFilmIdAndName()
    {
        var data = this._repository.GetIdAndName();

        return data;
    }
}