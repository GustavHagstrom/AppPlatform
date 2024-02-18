namespace AppPlatform.Shared.Builders;
public class AccessIdBuilder
{
    private readonly HashSet<string> _accessIds = new();

    public AccessIdBuilder AddAccessId(string accessId)
    {
        if (!_accessIds.Contains(accessId))
        {
            throw new InvalidOperationException($"AccessId {accessId} already exists");
        }
        _accessIds.Add(accessId);
        return this;
    }
    public IReadOnlyCollection<string> Build()
    {
        return _accessIds;
    }
}
