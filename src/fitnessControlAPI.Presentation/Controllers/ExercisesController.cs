using fitnessControlAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fitnessControlAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExercisesController(IExerciseRepository repository) : ControllerBase
{
    private readonly IExerciseRepository _repository = repository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var exercise = await _repository.GetByIdAsync(id);
        
        if (exercise == null)
        {
            return NotFound();
        }
        return Ok(exercise);
    }
}