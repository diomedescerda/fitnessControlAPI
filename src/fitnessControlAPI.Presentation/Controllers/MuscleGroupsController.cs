using fitnessControlAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fitnessControlAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MuscleGroupsController(IMuscleGroupRepository repository) : ControllerBase
{
    private readonly IMuscleGroupRepository _repository = repository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var muscleGroup = await _repository.GetByIdAsync(id);
        
        if (muscleGroup == null)
        {
            return NotFound();
        }
        return Ok(muscleGroup);
    }
}