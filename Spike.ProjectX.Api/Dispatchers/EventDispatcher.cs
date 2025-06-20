using Microsoft.AspNetCore.SignalR.Client;
using Spike.ProjectX.Api.Models;
using Spike.ProjectX.Api.Utility;

namespace Spike.ProjectX.Api.Events
{
    /// <summary>
    /// Base class for event hubs that handle events of type <typeparamref name="TEvent"/>.
    /// </summary>
    /// <typeparam name="TEvent">The type of <see cref="IEvent"/>.</typeparam>
    public abstract class EventDispatcher<TEvent> : IEventDispatcher<TEvent>
        where TEvent : IEvent
    {
        protected HubConnection hubConnection;
        protected bool isDisposed;
        protected string publishMethod;
        protected List<IObserver<TEvent>> observers = new();

        // This needs to be moved to a cache or a persisted store.
        protected List<TEvent> events = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="EventDispatcher{TEvent}"/>
        /// class with the specified <paramref name="connection"/>.
        /// </summary>
        /// <param name="connection">The <see cref="HubConnection"/>.</param>
        protected EventDispatcher(HubConnection connection)
        {            
            hubConnection = Guard.NotNull(connection, nameof(connection));
            hubConnection.On<TEvent>(PublishMethodName, Publish);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventDispatcher{TEvent}"/>
        /// class with the specified <paramref name="connection"/>.
        /// </summary>
        /// <param name="connection">The <see cref="HubConnection"/>.</param>
        /// /// <param name="publishMethodName">The method name used to subscribe to published events.</param>
        protected EventDispatcher(HubConnection connection, string publishMethodName)
        {            
            hubConnection = Guard.NotNull(connection, nameof(connection));
            publishMethod = Guard.NotNullOrEmpty(publishMethodName, nameof(publishMethodName));
            hubConnection.On<TEvent>(publishMethod, Publish);
        }

        /// <summary>
        /// Gets the name of the method used to subscribe to events
        /// from the hub.
        /// </summary>
        public virtual string PublishMethodName 
        { 
            get => publishMethod; 
            protected set => publishMethod = value;
        }

        /// <summary>
        /// Publishes an event to all observers and stores it in the event list.
        /// </summary>
        /// <param name="event">The <see cref="IEvent"/>.</param>
        public virtual void Publish(TEvent @event)
        {
            Guard.NotNull(@event, nameof(@event));
            events.Add(@event);
            foreach (var observer in observers)
            {
                observer.OnNext(@event);
            }
        }

        /// <summary>
        /// Subscribes an observer to the event hub.
        /// </summary>
        /// <param name="observer">The <see cref="IObserver{T}"/>.</param>
        /// <returns>A disposable instance of the <see cref="IObserver{T}"/>.</returns>
        public virtual IDisposable Subscribe(IObserver<TEvent> observer)
        {
            Guard.NotNull(observer, nameof(observer));
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
                foreach (var @event in events)
                {
                    observer.OnNext(@event);
                }
            }
            return new Unsubscriber<TEvent>(observers, observer);
        }

        /// <summary>
        /// Disposes the resources used by the <see cref="EventDispatcher{TEvent}"/> class.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the resources used by the <see cref="EventDispatcher{TEvent}"/> class.
        /// </summary>
        /// <param name="disposing">true if disposing; otherwise, false.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    events.Clear();
                    observers.Clear();
                }
                // This is shared. Just set locaL reference to null.
                hubConnection = null;
                isDisposed = true;
            }
        }
    }
}