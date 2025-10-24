using System.ComponentModel.DataAnnotations;

namespace OficiosUy.Api.Models;

public class UserDto
{
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "First Name is a required field")]
    [MaxLength(50)]
    public required String FirstName { get; set; }
    
    [Required(ErrorMessage = "LastName is a required field")]
    [MaxLength(50)]
    public required String LastName { get; set; }
    
    [MaxLength(100)]
    [EmailAddress]
    [Required(ErrorMessage = "Email is a required field")]
    public required String Email { get; set; }
    
    [MaxLength(50)]
    [Required(ErrorMessage = "Phone is a required field")]
    public required String Phone { get; set; }
}