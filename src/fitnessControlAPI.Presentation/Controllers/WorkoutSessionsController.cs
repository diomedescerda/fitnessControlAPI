using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using fitnessControlAPI.Presentation.DTOs.WorkoutSession;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace fitnessControlAPI.Presentation.Controllers;

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
    public async Task<IActionResult> GetById(Guid id)
    {
        var workoutSession = await _repository.GetByIdAsync(id);
        
        if (workoutSession == null)
        {
            return NotFound();
        }

        var response = workoutSession.Adapt<WorkoutSessionResponse>();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWorkoutSessionRequest request)
    {
        var workoutSession = new WorkoutSession
        {
            UserId = request.UserId,
            Date = request.Date,
            Notes = request.Notes,
            WorkoutExercises = request.WorkoutExercises.Select(we => new WorkoutExercise
                {
                    ExerciseId = we.ExerciseId,
                    OrderNumber = we.OrderNumber,
                    ExerciseSets = we.ExerciseSets.Select(es => new ExerciseSet
                        {
                            SetNumber = es.SetNumber,
                            Reps = es.Reps,
                            Weight = es.Weight,
                        }).ToList()
                }).ToList()
        };

        var created = await _repository.CreateAsync(workoutSession);
        var response = created.Adapt<WorkoutSessionResponse>();
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateWorkoutSessionRequest request)
    {
        var workoutSession = await _repository.GetByIdAsync(id);

        if (workoutSession is null)
            return NotFound();
        
        workoutSession.UserId = request.UserId;
        workoutSession.Date = request.Date;
        workoutSession.Notes = request.Notes;
        
        await _repository.UpdateAsync(workoutSession);
        return Ok(workoutSession.Adapt<WorkoutSessionResponse>());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var workoutSession = await _repository.GetByIdAsync(id);
        
        if (workoutSession is null)
            return NotFound();
        
        await _repository.DeleteAsync(workoutSession.Id);
        
        return NoContent();
    }
}
