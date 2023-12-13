namespace Server.Enteties;

public class UserOrganization
{
    public string UserId { get; set; } = string.Empty;
    public User? User { get; set; }
    public Guid OrganizationId { get; set; }
    public Organization? Organization { get; set; }

}

