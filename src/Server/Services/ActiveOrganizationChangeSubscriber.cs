using Server.Components.Shared.StateManagment;
using Server.Enteties;

namespace Server.Services;

public class ActiveOrganizationChangeSubscriber : IActiveOrganizationChangeSubscriber
{
    private ActiveOrganizationContainer? _activeOrganizationContainer;
    Func<Organization, Task>? _onChangeTask;
    public void SetSubscription(ActiveOrganizationContainer activeOrganizationContainer, Func<Organization, Task> OnChangeTask)
    {
        Dispose();
        _activeOrganizationContainer = activeOrganizationContainer;
        _onChangeTask = OnChangeTask;
    }
    public void Dispose()
    {
        if (_activeOrganizationContainer != null)
        {
            _activeOrganizationContainer.OnActiveOrganizationChanged -= _onChangeTask;
        }
    }

}