using Microsoft.AspNetCore.SignalR.Client;
using Spike.ProjectX.Api.Models.MarketData;

namespace Spike.ProjectX.Api.Events
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarketTradeHub"/> class.
    /// </summary>
    /// <param name="connection">The <see cref="HubConnection"/>.</param>
    public class MarketTradeHub(HubConnection connection) : 
        MultiEventDispatcher<List<MarketTradeEvent>, MarketTradeEvent>(connection, "GatewayTrade"),
        IEventDispatcher<MarketTradeEvent>
    {
    }
}