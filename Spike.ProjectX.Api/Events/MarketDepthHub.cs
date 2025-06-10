using Microsoft.AspNetCore.SignalR.Client;
using Spike.ProjectX.Api.Models.MarketData;

namespace Spike.ProjectX.Api.Events
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarketDepthHub[]"/> class.
    /// </summary>
    public class MarketDepthHub(HubConnection connection) :
        MultiEventHub<List<MarketDepthEvent>, MarketDepthEvent>(connection, "GatewayDepth"),
        IEventHub<MarketDepthEvent>
    {
    }
}