using FilmProductionSystem.DTOs;
using FilmProductionSystem.Models;
using FilmProductionSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmProductionSystem.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ScheduleController: ControllerBase
{
    private readonly IScheduleRepository _scheduleRepository;

    public ScheduleController(IScheduleRepository scheduleRepository)
    {
        this._scheduleRepository = scheduleRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewSchedule([FromQuery] Guid filmId, [FromBody] AddScheduleDTO dto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                Schedule schedule = await this._scheduleRepository.AddNewScheduleDetails(dto, filmId);
                return Ok(schedule);
            }
            else
            {
                return Ok(ModelState.ValidationState.ToString());
            }
        }
        catch(Exception ex)
        {
            return BadRequest(ex);
        }
    } 
    
}