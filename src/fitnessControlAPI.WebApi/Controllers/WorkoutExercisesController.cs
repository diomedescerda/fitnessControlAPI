using fitnessControlAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fitnessControlAPI.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutExercisesController(IWorkoutExerciseRepository repository) : ControllerBase
{
    private readonly IWorkoutExerciseRepository _repository = repository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var workoutExercise = await _repository.GetByIdAsync(id);
        
        if (workoutExercise == null)
        {
            return NotFound();
        }
        return Ok(workoutExercise);
    }
}