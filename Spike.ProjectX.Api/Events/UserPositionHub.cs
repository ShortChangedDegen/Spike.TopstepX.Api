using Microsoft.AspNetCore.SignalR.Client;
using Spike.ProjectX.Api.Models.Positions;
using System;

namespace Spike.ProjectX.Api.Events
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarketTradeHub"/> class.
    /// </summary>
    /// <param name="connection">The <see cref="HubConnection"/>.</param>
    public class UserPositionHub(HubConnection connection) :
        EventHub<UserPositionEvent>(connection, "GatewayUserPosition"),
        IEventHub<UserPositionEvent>
    {
    }
}
