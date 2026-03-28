using fitnessControlAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fitnessControlAPI.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutSessionsController(IWorkoutSessionRepository repository) : ControllerBase
{
    private readonly IWorkoutSessionRepository _repository = repository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var workoutSession = await _repository.GetByIdAsync(id);
        
        if (workoutSession == null)
        {
            return NotFound();
        }
        return Ok(workoutSession);
    }
}