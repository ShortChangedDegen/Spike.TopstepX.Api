using Microsoft.AspNetCore.SignalR.Client;
using Spike.ProjectX.Api.Models.Positions;
using System;

namespace Spike.ProjectX.Api.Events
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarketTradeHub"/> class.
    /// </summary>
    /// <param name="connection">The <see cref="HubConnection"/>.</param>
    public class UserPositionEventDispatcher(HubConnection connection) :
        EventDispatcher<UserPositionEvent>(connection, "GatewayUserPosition"),
        IEventDispatcher<UserPositionEvent>
    {
    }
}
