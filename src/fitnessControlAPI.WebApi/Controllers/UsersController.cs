using fitnessControlAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fitnessControlAPI.WebApi.Controllers;

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
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}