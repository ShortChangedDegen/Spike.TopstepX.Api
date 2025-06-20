using Microsoft.AspNetCore.SignalR.Client;
using Spike.ProjectX.Api.Models;
using Spike.ProjectX.Api.Models.MarketData;
using Spike.ProjectX.Api.Utility;

namespace Spike.ProjectX.Api.Events
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarketQuoteHub"/> class.
    /// </summary>
    public class MarketQuoteHub : 
        EventDispatcher<MarketQuoteEvent>, 
        IEventDispatcher<MarketQuoteEvent>
    {
        public MarketQuoteHub(HubConnection connection)
            : base(connection, "GatewayQuote") // Pass parameters to the base class constructor
        {            
        }

        /// <summary>
        /// Publishes an event to all observers and stores it in the event list.
        /// </summary>
        /// <param name="id">The event ID.</param>
        /// <param name="event">The <see cref="MarketQuoteEvent"/>.</param>
        public void Publish(string id, MarketQuoteEvent @event)
        {
            Console.WriteLine($"Publishing MarketQuoteEvent with ID: {id}");
            base.Publish(@event);
        }
    }
}