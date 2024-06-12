using AppPlatform.Core.Enteties.Abstractions;
using AppPlatform.Core.Enteties.EstimationView;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties;

public class UserViewTemplate : IUserEntety
{
    [StringLength(450)]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [StringLength(450)]
    public string EstimationViewTemplateId { get; set; } = string.Empty;
    public View? EstimationViewTemplate { get; set; }
    public string UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
