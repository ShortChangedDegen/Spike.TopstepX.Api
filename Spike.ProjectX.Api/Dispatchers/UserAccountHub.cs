using Microsoft.AspNetCore.SignalR.Client;
using Spike.ProjectX.Api.Models.Account;

namespace Spike.ProjectX.Api.Events
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserAccountHub"/> class.
    /// </summary>
    /// <param name="connection">The <see cref="HubConnection"/>.</param>
    public class UserAccountHub(HubConnection connection) : 
        EventDispatcher<UserAccountEvent>(connection, "GatewayUserAccount"), 
        IEventDispatcher<UserAccountEvent>
    {        
    }
}