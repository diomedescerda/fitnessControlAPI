using fitnessControlAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fitnessControlAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RunningSessionsController(IRunningSessionRepository repository) : ControllerBase
{
    private readonly IRunningSessionRepository _repository = repository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var runningSession = await _repository.GetByIdAsync(id);
        
        if (runningSession == null)
        {
            return NotFound();
        }
        return Ok(runningSession);
    }
}