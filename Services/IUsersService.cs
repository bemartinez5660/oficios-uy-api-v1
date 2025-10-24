using OficiosUy.Api.Models;
using OficiosUy.Api.Models.Entities;

namespace OficiosUy.Api.Services;

public interface IUsersService
{
    Task<User> SaveUser(UserDto user);
    Task<UserDto?> GetUserById(Guid id);
    Task<UserDto?> UpdateUserAsync(Guid id, UpdateUserRequestDto updateUserRequestDto);
}