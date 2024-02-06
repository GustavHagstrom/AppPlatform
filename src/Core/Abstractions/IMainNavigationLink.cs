namespace AppPlatform.Core.Abstractions;
public interface IMainNavigationLink
{
    string LinkRoute { get; }
    string Text { get; }
    string Icon { get; }
}
