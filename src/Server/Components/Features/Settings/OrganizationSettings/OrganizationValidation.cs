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
    public string ExpireDate(DateTime? value)
    {
        if (value == null)
        {
            return Localizer["Utgångsdatum är obligatoriskt"];
        }
        if (value < DateTime.Now)
        {
            return Localizer["Utgångsdatum får inte vara i det förflutna"];
        }
        return string.Empty;
    }
    public string UserLimit(int value)
    {
        if (value < 1)
        {
            return Localizer["Användarantal får inte vara mindre än 1"];
        }
        return string.Empty;
    }
}
