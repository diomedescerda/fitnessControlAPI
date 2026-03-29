using fitnessControlAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fitnessControlAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExerciseSetsController(IExerciseSetRepository repository) : ControllerBase
{
    private readonly IExerciseSetRepository _repository = repository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var exerciseSet = await _repository.GetByIdAsync(id);
        
        if (exerciseSet == null)
        {
            return NotFound();
        }
        return Ok(exerciseSet);
    }
}