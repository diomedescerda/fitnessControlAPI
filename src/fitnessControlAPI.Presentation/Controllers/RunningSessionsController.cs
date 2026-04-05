using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using fitnessControlAPI.Presentation.DTOs.RunningSession;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace fitnessControlAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RunningSessionsController(IRunningSessionRepository repository) : ControllerBase
{
    private readonly IRunningSessionRepository _repository = repository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var runningSession = await _repository.GetByIdAsync(id);
        
        if (runningSession == null)
        {
            return NotFound();
        }

        var response = runningSession.Adapt<RunningSessionResponse>();
        return Ok(response);
    }

    [HttpGet("weeklyDistance/{userId}/{offset}")]
    public async Task<IActionResult> GetWeeklyDistanceAndOffsetByUserId(Guid userId, int offset)
    {
        return Ok(await _repository.GetWeeklyDistanceByUserIdAndOffsetAsync(userId, offset));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRunningSessionRequest request)
    {
        var runningSession = new RunningSession
        {
            UserId = request.UserId,
            Date = request.Date,
            Distance = request.Distance,
            Duration = request.Duration,
            AvgHeartRate = request.AvgHeartRate,
            MaxHeartRate = request.MaxHeartRate,
            CaloriesBurned = request.CaloriesBurned,
            Notes = request.Notes,
        };

        var created = await _repository.CreateAsync(runningSession);
        return Ok(created.Adapt<CreateRunningSessionRequest>());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRunningSessionRequest request)
    {
        var runningSession = await _repository.GetByIdAsync(id);

        if (runningSession is null)
            return NotFound();
        
        runningSession.UserId = request.UserId;
        runningSession.Date = request.Date;
        runningSession.Distance = request.Distance;
        runningSession.Duration = request.Duration;
        runningSession.AvgHeartRate = request.AvgHeartRate;
        runningSession.MaxHeartRate = request.MaxHeartRate;
        runningSession.CaloriesBurned = request.CaloriesBurned;
        runningSession.Notes = request.Notes;
        
        await _repository.UpdateAsync(runningSession);
        return Ok(runningSession.Adapt<RunningSessionResponse>());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var runningSession = await _repository.GetByIdAsync(id);
        
        if (runningSession is null)
            return NotFound();
        
        await _repository.DeleteAsync(runningSession.Id);
        
        return NoContent();
    }
}
