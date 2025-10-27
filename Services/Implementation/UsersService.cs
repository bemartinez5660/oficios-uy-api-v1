using OficiosUy.Api.Data;
using OficiosUy.Api.Models;
using OficiosUy.Api.Models.Entities;

namespace OficiosUy.Api.Services.Implementation;

public class UsersService(ApplicationDbContext _context) : IUsersService
{
    public async Task<User> SaveUser(UserDto user)
    {
        User newUser = new User
        {
            Id = Guid.NewGuid(),
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Phone = user.Phone
        };
        await _context.Users.AddAsync(newUser);
        _context.SaveChanges();
        return newUser;
    }

    public async Task<UserDto?> GetUserById(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return null;

        return new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Phone = user.Phone
        };
    }

    public async Task<UserDto?> UpdateUserAsync(Guid id, UpdateUserRequestDto updatedUserRequestDto)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return null;
        
        user.Email = updatedUserRequestDto.Email;
        user.FirstName = updatedUserRequestDto.FirstName;
        user.LastName = updatedUserRequestDto.LastName;
        user.Phone = updatedUserRequestDto.Phone;

        await _context.SaveChangesAsync();
        
        return new UserDto
        {
            Id = user.Id,
            Email = updatedUserRequestDto.Email,
            FirstName = updatedUserRequestDto.FirstName,
            LastName = updatedUserRequestDto.LastName,
            Phone = updatedUserRequestDto.Phone
        };
    }
}