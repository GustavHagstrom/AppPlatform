using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models;
public class LoginModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    [StringLength(50)]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [StringLength(50)]
    public string Password { get; set; } = string.Empty;
}
