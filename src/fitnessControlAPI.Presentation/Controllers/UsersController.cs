using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using fitnessControlAPI.Presentation.DTOs.User;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace fitnessControlAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserRepository repository) : ControllerBase
{
    private readonly IUserRepository _repository = repository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _repository.GetByIdAsync(id);
        
        if (user == null)
        {
            return NotFound();
        }
        
        var response = user.Adapt<UserResponse>();
        return Ok(Response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
        var user = new User
        {
            Name = request.Name,
            Height = request.Height,
            BirthDate = request.BirthDate
        };

        var created = await _repository.CreateAsync(user);
        var response = created.Adapt<UserResponse>();
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserRequest request)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user is null)
            return NotFound();
        
        user.Name = request.Name;
        user.Height = request.Height;
        user.BirthDate = request.BirthDate;
        
        await _repository.UpdateAsync(user);
        return Ok(user.Adapt<UserResponse>());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await _repository.GetByIdAsync(id);
        
        if (user is null)
            return NotFound();
        
        await _repository.DeleteAsync(user.Id);
        
        return NoContent();
    }
}