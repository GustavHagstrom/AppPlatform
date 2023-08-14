using System.Reflection;

namespace SharedPlatformLibrary.Utilities.Placeholder;
public static class PlaceholderFunctions
{
    public static IEnumerable<PlaceholderInfo> GetPlaceholderPreopertyInfos(Type type)
    {
        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            var attribute = (PlaceholderAttribute?)Attribute.GetCustomAttribute(property, typeof(PlaceholderAttribute));
            if (attribute is not null)
            {
                yield return new PlaceholderInfo(attribute.Placeholder, property);
            }
        }
    }
    public static string CreateReplacedPlaceholderString(string stringWithPlaceholders, object entity)
    {
        var entityType = entity.GetType();
        var placeholderInfos = GetPlaceholderPreopertyInfos(entityType);
        foreach (var info in placeholderInfos)
        {
            stringWithPlaceholders = stringWithPlaceholders.Replace(info.Placeholder, info.PropertyInfo.GetValue(entity)?.ToString());
        }
        return stringWithPlaceholders;
    }
}
