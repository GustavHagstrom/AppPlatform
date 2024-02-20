namespace AppPlatform.Shared.Abstractions;
public interface IAccessClaimInfo
{
    string Value { get; }
    string Name { get; }
    string Description { get; }
}
