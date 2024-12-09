using FilmProductionSystem.DTOs;
using FilmProductionSystem.Models;
using FilmProductionSystem.Repositories;
using FilmProductionSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FilmProductionSystem.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class FilmsController: ControllerBase
{
    private readonly IFilmServices _filmServices;

    public FilmsController(IFilmServices filmServices)
    {
        this._filmServices = filmServices;
    }
    [HttpPost]
    public async Task<IActionResult> AddNewFilm([FromBody]AddFilmDTO dto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var data = this._filmServices.AddFilmsAsync(dto);
                return Ok(data);
            }
            else
            {
                return BadRequest();
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFilmIds()
    {
        try
        {
            List<ViewFilmIdandNameDTO> data = await this._filmServices.GetAllFilmIdAndName();
            return Ok(data);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}