namespace SharedPlatformLibrary.Utilities.Placeholder;
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class PlaceholderAttribute : Attribute
{
    public string Placeholder { get; }

    public PlaceholderAttribute(string placehold)
    {
        Placeholder = placehold;
    }
}
