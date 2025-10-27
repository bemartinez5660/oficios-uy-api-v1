using Microsoft.AspNetCore.Mvc;
using OficiosUy.Api.Models;
using OficiosUy.Api.Services;

namespace OficiosUy.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }


    [HttpPost]
    public async Task<IActionResult> SaveUser([FromBody] UserDto userDto)
    {
        var user = await _usersService.SaveUser(userDto);
        if (user == null) return NotFound(new { success = false, message = "No se pudo insertar el usuario" });
        return Ok(new { success = true, user });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserRequestDto updateUserRequest)
    {
        var newUser = await _usersService.UpdateUserAsync(id, updateUserRequest);
        if (newUser == null) return NotFound(new {success = false, message = "No existe este id de usuario"});
        
        return Ok(new { success = true, newUser });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _usersService.GetUserById(id);
        if (user == null) return NotFound(new { success = false, message = "No existe este id de usuario"});
        return Ok(new { success = true, user });
    }
}