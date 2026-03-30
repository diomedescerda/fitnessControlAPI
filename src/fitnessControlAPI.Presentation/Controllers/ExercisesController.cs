using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using fitnessControlAPI.Presentation.DTOs.Exercise;
using Mapster;
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

        var response = exercise.Adapt<ExerciseResponse>();
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateExerciseRequest request)
    {
        var exercise = new Exercise
        {
            Name = request.Name,
            Description = request.Description,
            CategoryId =  request.CategoryId,
            IsCustom =  request.IsCustom
        };

        var created = await _repository.CreateAsync(exercise);
        var response = created.Adapt<ExerciseResponse>();
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateExerciseRequest request)
    {
        var exercise = await _repository.GetByIdAsync(id);

        if (exercise is null)
            return NotFound();
        
        exercise.Name = request.Name;
        exercise.Description = request.Description;
        exercise.CategoryId =  request.CategoryId;
        exercise.IsCustom = request.IsCustom;
        
        await _repository.UpdateAsync(exercise);
        return Ok(exercise.Adapt<ExerciseResponse>());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var exercise = await _repository.GetByIdAsync(id);
        
        if (exercise is null)
            return NotFound();
        
        await _repository.DeleteAsync(exercise.Id);
        
        return NoContent();
    }
}
