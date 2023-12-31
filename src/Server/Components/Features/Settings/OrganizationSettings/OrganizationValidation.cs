using Microsoft.Extensions.Localization;

namespace Server.Components.Features.Settings.OrganizationSettings;

public class OrganizationValidation(IStringLocalizer<OrganizationValidation> Localizer)
{
    public string ValidateName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Localizer["Namn är obligatoriskt"];
        }
        if (value.Length > 50)
        {
            return Localizer["Namn får inte vara längre än 50 tecken"];
        }
        return string.Empty;
    }
}
