using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using fitnessControlAPI.Presentation.DTOs.BodyMeasurement;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace fitnessControlAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BodyMeasurementsController(IBodyMeasurementRepository repository) : ControllerBase
{
    private readonly IBodyMeasurementRepository _repository = repository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var bodyMeasurement = await _repository.GetByIdAsync(id);
        
        if (bodyMeasurement == null)
        {
            return NotFound();
        }
        
        var response = bodyMeasurement.Adapt<BodyMeasurementResponse>();
        return Ok(response);
    }

    [HttpGet("recent/{userId}")]
    public async Task<IActionResult> GetMostRecentByUserId(Guid userId)
    {
        var bodyMeasurement = await _repository.GetMostRecentByUserIdAsync(userId);
        if (bodyMeasurement == null) return NotFound();
        return Ok(bodyMeasurement.Adapt<BodyMeasurementResponse>());
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBodyMeasurementRequest request)
    {
        var bodyMeasurement = new BodyMeasurement
        {
            UserId = request.UserId,
            Date = request.Date,
            Weight = request.Weight,
            Chest = request.Chest,
            Waist = request.Waist,
            Hips = request.Hips,
            Bicep = request.Bicep,
            Thigh = request.Thigh,
            Calf = request.Calf,
            Notes = request.Notes
        };

        var created = await _repository.CreateAsync(bodyMeasurement);
        var response = created.Adapt<BodyMeasurementResponse>();
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBodyMeasurementRequest request)
    {
        var bodyMeasurement = await _repository.GetByIdAsync(id);

        if (bodyMeasurement is null)
            return NotFound();
        
        bodyMeasurement.UserId = request.UserId;
        bodyMeasurement.Date = request.Date;
        bodyMeasurement.Weight = request.Weight;
        bodyMeasurement.Chest = request.Chest;
        bodyMeasurement.Waist = request.Waist;
        bodyMeasurement.Hips = request.Hips;
        bodyMeasurement.Bicep = request.Bicep;
        bodyMeasurement.Thigh = request.Thigh;
        bodyMeasurement.Calf = request.Calf;
        bodyMeasurement.Notes = request.Notes;
        
        await _repository.UpdateAsync(bodyMeasurement);
        return Ok(bodyMeasurement.Adapt<BodyMeasurementResponse>());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var bodyMeasurement = await _repository.GetByIdAsync(id);
        
        if (bodyMeasurement is null)
            return NotFound();
        
        await _repository.DeleteAsync(bodyMeasurement.Id);
        
        return NoContent();
    }
}
