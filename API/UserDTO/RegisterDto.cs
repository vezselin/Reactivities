using System.ComponentModel.DataAnnotations;

namespace API.UserDTO;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", ErrorMessage = "Password must contain lower case, upper case letter and lenght between 4-8")]
    public string Password { get; set; }
    [Required]
    public string DisplayName { get; set; }
    public string Username { get; set; }
}