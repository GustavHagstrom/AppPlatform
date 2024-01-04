using Server.Components.Shared.StateManagment;
using Server.Enteties;

namespace Server.Services;
public interface IActiveOrganizationChangeService : IDisposable
{
    void SetSubscription(ActiveOrganizationContainer activeOrganizationContainer, Func<Organization, Task> OnChangeTask);
}