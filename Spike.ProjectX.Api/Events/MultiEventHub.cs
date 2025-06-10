using Microsoft.AspNetCore.SignalR.Client;
using Spike.ProjectX.Api.Models;
using Spike.ProjectX.Api.Utility;

namespace Spike.ProjectX.Api.Events
{
    public abstract class MultiEventHub<T, TEvent> : EventHub<TEvent>, IEventHub<TEvent>
        where T : ICollection<TEvent>, new()
        where TEvent : IEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventHub{TEvent}"/>
        /// class with the specified <paramref name="connection"/>.
        /// </summary>
        /// <param name="connection">The <see cref="HubConnection"/>.</param>
        /// /// <param name="publishMethodName">The method name used to subscribe to published events.</param>
        protected MultiEventHub(HubConnection connection, string publishMethodName)
            : base(connection, publishMethodName)
        {
            Guard.NotNull(connection, nameof(connection));
            hubConnection = connection;
            publishMethod = publishMethodName;
            hubConnection.On<string, T>(publishMethodName, Publish);
        }


        /// <summary>
        /// Publishes an event to all observers and stores it in the event list.
        /// </summary>
        /// <param name="event">The <see cref="IEvent"/>.</param>
        public virtual void Publish(string id, T @events)
        {
            Guard.NotNull(@events, nameof(@events));
            Console.WriteLine($"Publishing events with ID: {id}");
            foreach (var @event in @events)
            {
                base.Publish(@event);
            }            
        }
    }
}
