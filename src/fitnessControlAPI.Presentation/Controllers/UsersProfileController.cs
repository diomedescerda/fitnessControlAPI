using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using fitnessControlAPI.Presentation.DTOs.User;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace fitnessControlAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersProfileController(IUserProfileRepository profileRepository) : ControllerBase
{
    private readonly IUserProfileRepository _profileRepository = profileRepository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _profileRepository.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _profileRepository.GetByIdAsync(id);
        
        if (user == null)
        {
            return NotFound();
        }
        
        var response = user.Adapt<UserProfileResponse>();
        return Ok(Response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserProfileRequest profileRequest)
    {
        var user = new UserProfile
        {
            Name = profileRequest.Name,
            Height = profileRequest.Height,
            BirthDate = profileRequest.BirthDate
        };

        var created = await _profileRepository.CreateAsync(user);
        var response = created.Adapt<UserProfileResponse>();
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserProfileRequest profileRequest)
    {
        var user = await _profileRepository.GetByIdAsync(id);

        if (user is null)
            return NotFound();
        
        user.Name = profileRequest.Name;
        user.Height = profileRequest.Height;
        user.BirthDate = profileRequest.BirthDate;
        
        await _profileRepository.UpdateAsync(user);
        return Ok(user.Adapt<UserProfileResponse>());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await _profileRepository.GetByIdAsync(id);
        
        if (user is null)
            return NotFound();
        
        await _profileRepository.DeleteAsync(user.Id);
        
        return NoContent();
    }
}