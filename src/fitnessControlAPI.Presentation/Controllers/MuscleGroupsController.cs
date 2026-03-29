using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using fitnessControlAPI.Presentation.DTOs.MuscleGroup;
using Mapster;
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
        
        var response = muscleGroup.Adapt<MuscleGroupResponse>();
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMuscleGroupRequest request)
    {
        var muscleGroup = new MuscleGroup
        {
            Name = request.Name
        };

        var created = await _repository.CreateAsync(muscleGroup);
        var response = created.Adapt<MuscleGroupResponse>();
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateMuscleGroupRequest request)
    {
        var muscleGroup = await _repository.GetByIdAsync(id);

        if (muscleGroup is null)
            return NotFound();
        
        muscleGroup.Name = request.Name;
        
        await _repository.UpdateAsync(muscleGroup);
        return Ok(muscleGroup.Adapt<MuscleGroupResponse>());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var muscleGroup = await _repository.GetByIdAsync(id);
        
        if (muscleGroup is null)
            return NotFound();
        
        await _repository.DeleteAsync(muscleGroup.Id);
        
        return NoContent();
    }
}