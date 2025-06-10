using Microsoft.AspNetCore.SignalR.Client;
using Spike.ProjectX.Api.Models.Trades;

namespace Spike.ProjectX.Api.Events
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserTradeHub"/> class.
    /// </summary>
    /// <param name="connection">The <see cref="HubConnection"/>.</param>
    public class UserTradeHub(HubConnection connection) : 
        EventHub<UserTradeEvent>(connection, "GatewayUserTrade"),
        IEventHub<UserTradeEvent>
    {
    }
}