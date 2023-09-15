using BidConReport.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Enteties;

public class RoleRight
{
    public Guid Id { get; set; }
    public ApplicationRight Right { get; set; }
    public Guid RoleId { get; set; }
    public Role? Role { get; set; }
}
