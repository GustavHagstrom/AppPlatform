using AppPlatform.Core.Enteties.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties;

public class Estimation : ITenantEntety
{
    [StringLength(450)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string TenantId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
