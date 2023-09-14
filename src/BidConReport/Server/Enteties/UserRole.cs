namespace BidConReport.Server.Enteties;

public class UserRole
{
    public required string UserId { get; set; }
    public User? User { get; set; }
    public required Guid RoleId { get; set; }
    public Role? Role { get; set; }
}
