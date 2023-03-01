using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Features.Authorization.Models;

public class Role
{
    //public int Id { get; set; }
    [MaxLength(20)]
    public required string Name { get; set; }
}
