using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models;
public class User 
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    [StringLength(50)]
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}
