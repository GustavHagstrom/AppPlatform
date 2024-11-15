namespace AppPlatform.Shared.Utilities;
public interface IRule<T> where T : class
{
    void Apply(T obj);
}
