using fitnesControlAPI.Presentation.DTOs.ExerciseCategory;
using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace fitnessControlAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExerciseCategoriesController(IExerciseCategoryRepository repository) : ControllerBase
{
    private readonly IExerciseCategoryRepository _repository = repository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var exerciseCategory = await _repository.GetByIdAsync(id);
        
        if (exerciseCategory == null)
        {
            return NotFound();
        }

        var response = exerciseCategory.Adapt<ExerciseCategoryResponse>();
        return Ok(response);
    }
    
        
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateExerciseCategoryRequest request)
    {
        var exerciseCategory = new ExerciseCategory
        {
            Name = request.Name,
            Description = request.Description,
        };

        var created = await _repository.CreateAsync(exerciseCategory);
        var response = created.Adapt<ExerciseCategoryResponse>();
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateExerciseCategoryRequest request)
    {
        var exerciseCategory = await _repository.GetByIdAsync(id);

        if (exerciseCategory is null)
            return NotFound();
        
        exerciseCategory.Name = request.Name;
        exerciseCategory.Description = request.Description;
        
        await _repository.UpdateAsync(exerciseCategory);
        return Ok(exerciseCategory.Adapt<ExerciseCategoryResponse>());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var exerciseCategory = await _repository.GetByIdAsync(id);
        
        if (exerciseCategory is null)
            return NotFound();
        
        await _repository.DeleteAsync(exerciseCategory.Id);
        
        return NoContent();
    }
}
