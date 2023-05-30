using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedWasmLibrary.Features.Authentication;
public interface IAuthStateTrigger
{
    void SetTriggerAction(Func<Task> triggerTask);
    Task TriggerAuthStateChangedAsync();
}
