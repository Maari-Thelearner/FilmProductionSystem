using Microsoft.AspNetCore.Mvc;
using FilmProductionSystem.DTOs;
using FilmProductionSystem.Repositories;

namespace FilmProductionSystem.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CrewController : ControllerBase
{
    private readonly ICrewRepository _crewRepository;

    public CrewController(ICrewRepository crewRepository)
    {
        this._crewRepository = crewRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewCrew([FromBody]AddCrewDTO dto,[FromQuery] Guid filmId)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var data = await this._crewRepository.AddCrewDetailsAsync(dto, filmId);
                return Ok(data);
            }
            else
            {
                return Ok(ModelState.ValidationState.ToString());
            }
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}