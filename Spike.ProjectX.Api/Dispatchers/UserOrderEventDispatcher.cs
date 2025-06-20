﻿using Microsoft.AspNetCore.SignalR.Client;
using Spike.ProjectX.Api.Models.Orders;

namespace Spike.ProjectX.Api.Events
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserOrderEventDispatcher"/> class.
    /// </summary>
    /// <param name="connection">The <see cref="HubConnection"/>.</param>
    public class UserOrderEventDispatcher(HubConnection connection) : 
        EventDispatcher<UserOrderEvent>(connection, "GatewayUserOrder"), 
        IEventDispatcher<UserOrderEvent>
    {        
    }
}