using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using fitnessControlAPI.Presentation.DTOs.WorkoutSession;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace fitnessControlAPI.Presentation.Controllers;

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
    public async Task<IActionResult> GetById(Guid id)
    {
        var workoutExercise = await _repository.GetByIdAsync(id);
        
        if (workoutExercise == null)
        {
            return NotFound();
        }

        var response = workoutExercise.Adapt<WorkoutExerciseResponse>();
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWorkoutExerciseRequest request)
    {
        var workoutExercise = new WorkoutExercise
        {
            WorkoutSessionId = request.WorkoutSessionId,
            ExerciseId = request.ExerciseId,
            OrderNumber = request.OrderNumber,
            Notes = request.Notes,
        };

        var created = await _repository.CreateAsync(workoutExercise);
        var response = created.Adapt<WorkoutExerciseResponse>();
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateWorkoutExerciseRequest request)
    {
        var workoutExercise = await _repository.GetByIdAsync(id);

        if (workoutExercise is null)
            return NotFound();
        
        workoutExercise.WorkoutSessionId = request.WorkoutSessionId;
        workoutExercise.ExerciseId = request.ExerciseId;
        workoutExercise.OrderNumber = request.OrderNumber;
        workoutExercise.Notes = request.Notes;
        
        await _repository.UpdateAsync(workoutExercise);
        return Ok(workoutExercise.Adapt<WorkoutExerciseResponse>());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var workoutExercise = await _repository.GetByIdAsync(id);
        
        if (workoutExercise is null)
            return NotFound();
        
        await _repository.DeleteAsync(workoutExercise.Id);
        
        return NoContent();
    }
}
