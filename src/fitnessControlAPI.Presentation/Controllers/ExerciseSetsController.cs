using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using fitnessControlAPI.Presentation.DTOs.ExerciseSet;
using Mapster;
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
    public async Task<IActionResult> GetById(Guid id)
    {
        var exerciseSet = await _repository.GetByIdAsync(id);
        
        if (exerciseSet == null)
        {
            return NotFound();
        }

        var response = exerciseSet.Adapt<ExerciseSetResponse>();
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateExerciseSetRequest request)
    {
        var exerciseSet = new ExerciseSet
        {
            WorkoutExerciseId = request.WorkoutExerciseId,
            SetNumber = request.SetNumber,
            Reps = request.Reps,
            Weight = request.Weight,
        };

        var created = await _repository.CreateAsync(exerciseSet);
        var response = created.Adapt<ExerciseSetResponse>();
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateExerciseSetRequest request)
    {
        var exerciseSet = await _repository.GetByIdAsync(id);

        if (exerciseSet is null)
            return NotFound();

        exerciseSet.WorkoutExerciseId = request.WorkoutExerciseId;
        exerciseSet.SetNumber = request.SetNumber;
        exerciseSet.Reps = request.Reps;
        exerciseSet.Weight = request.Weight;
        
        await _repository.UpdateAsync(exerciseSet);
        return Ok(exerciseSet.Adapt<ExerciseSetResponse>());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var exerciseSet = await _repository.GetByIdAsync(id);
        
        if (exerciseSet is null)
            return NotFound();
        
        await _repository.DeleteAsync(exerciseSet.Id);
        
        return NoContent();
    }
}
