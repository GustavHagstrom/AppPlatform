namespace AppPlatform.Shared.Abstractions;
public interface IApplicationLink
{
    string LinkRoute { get; }
    string Text { get; }
    string Icon { get; }
}
