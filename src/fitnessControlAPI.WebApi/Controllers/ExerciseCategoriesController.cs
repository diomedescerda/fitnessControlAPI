using fitnessControlAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fitnessControlAPI.WebApi.Controllers;

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
        return Ok(exerciseCategory);
    }
}