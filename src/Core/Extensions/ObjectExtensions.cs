namespace AppPlatform.Core.Extensions;

public static class ObjectExtensions
{
    public static T Apply<T>(this T obj, Action<T> action)
    {
        action?.Invoke(obj);
        return obj;
    }
}

