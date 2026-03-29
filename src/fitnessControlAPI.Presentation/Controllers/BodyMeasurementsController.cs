using fitnessControlAPI.Domain.Interfaces;
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
    public async Task<IActionResult> GetById(int id)
    {
        var bodyMeasurement = await _repository.GetByIdAsync(id);
        
        if (bodyMeasurement == null)
        {
            return NotFound();
        }
        return Ok(bodyMeasurement);
    }
}