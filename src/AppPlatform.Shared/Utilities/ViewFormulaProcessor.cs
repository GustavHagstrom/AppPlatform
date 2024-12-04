using AppPlatform.Core.Enteties.EstimationEnteties;
using AppPlatform.Shared.Constants;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace AppPlatform.Shared.Utilities;
public static class ViewFormulaProcessor
{
    private static readonly Dictionary<string, Func<Estimation, string?>> _formulas = new()
    {
        { Placeholders.Estimation.Id, estimation => estimation.Id },
        { Placeholders.Estimation.Name, estimation => estimation.Name },
        { Placeholders.Estimation.Description, estimation => estimation.Description },
        { Placeholders.Estimation.Customer, estimation => estimation.Customer },
        { Placeholders.Estimation.Place, estimation => estimation.Place },
        { Placeholders.Estimation.HandlingOfficer, estimation => estimation.HandlingOfficer },
        { Placeholders.Estimation.ConfirmationOfficer, estimation => estimation.ConfirmationOfficer },
        { Placeholders.Estimation.TenderTotal, estimation => estimation.TenderTotal?.ToString("N0") }
    };
    /// <summary>
    /// Processes the formula and replaces the placeholders with the values from the estimation.
    /// </summary>
    /// <param name="formula"></param>
    /// <param name="estimation"></param>
    /// <returns></returns>
    public static string Process(string formula, Estimation estimation)
    {
        //regex patterns for placeholders and calculation
        var placeholderPattern = @"\{([^\}]+)\}";

        return Regex.Replace(formula, placeholderPattern, match =>
        {
            var placeholder = match.Groups[0].Value;
            if (_formulas.ContainsKey(placeholder))
            {
                return _formulas[placeholder](estimation) ?? string.Empty;
            }
             return placeholder;
            
        });
    }

}
