namespace SharedWasmLibrary.Features.Authentication;
public class AuthStateTrigger : IAuthStateTrigger
{
    private Func<Task>? _triggerTask;
    public void SetTriggerAction(Func<Task> triggerTask)
    {

        _triggerTask = triggerTask;
    }

    public async Task TriggerAuthStateChangedAsync()
    {
        if( _triggerTask != null )
        {
            await _triggerTask.Invoke();
        }
        
    }
}
