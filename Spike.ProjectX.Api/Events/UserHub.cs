using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using Spike.ProjectX.Api.Models.Account;
using Spike.ProjectX.Api.Models.Orders;
using Spike.ProjectX.Api.Models.Positions;
using Spike.ProjectX.Api.Models.Trades;
using Spike.ProjectX.Api.Utility;

namespace Spike.ProjectX.Api.Events
{
    /// <summary>
    /// Represents a hub for user-related events such as account, order, position, and trade updates.
    /// </summary>
    public class UserHub : IDisposable, IUserHub
    {
        protected List<IDisposable> subscribers = new();

        protected IEventHub<UserAccountEvent> userAccountHub;
        protected IEventHub<UserOrderEvent> userOrderHub;
        protected IEventHub<UserPositionEvent> userPositionHub;
        protected IEventHub<UserTradeEvent> userTradeHub;

        protected readonly HubConnection hubConnection;
        protected readonly AuthTokenHandler authTokenHandler;
        protected bool isDisposed;
        private bool disposeHubConnection = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserHub"/> class.
        /// </summary>
        /// <param name="api">The ProjectX API.</param>
        /// <param name="settings">The ProjectX settings.</param>
        public UserHub(AuthTokenHandler authTokenHandler, IOptions<ProjectXSettings> projectXSettings)
        {
            Guard.NotNull(projectXSettings.Value, nameof(projectXSettings));

            authTokenHandler = Guard.NotNull(authTokenHandler, nameof(authTokenHandler));
            hubConnection = new HubConnectionBuilder()
                  .WithUrl($"{projectXSettings.Value.UserHubUrl}?access_token={authTokenHandler.GetToken()}")
                  .WithAutomaticReconnect()
                  .Build();
            disposeHubConnection = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserHub"/> class.
        /// </summary>
        /// <param name="connection">The shared <see cref="HubConnection">.</param>
        public UserHub(HubConnection connection) =>
            hubConnection = Guard.NotNull(connection, nameof(connection));

        /// <summary>
        /// Starts the <see cref="UserHub"/>.
        /// </summary>
        /// <returns>A task.</returns>
        public async Task StartAsync()
        {
            while (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }            
        }

        /// <summary>
        /// Gets an <see cref="EventHub{TEvent}"/> for <see cref="UserAccountEvent"/>s.
        /// </summary>
        public virtual IEventHub<UserAccountEvent> UserAccountHub =>
            userAccountHub ??= new UserAccountHub(hubConnection);

        /// <summary>
        /// Gets an <see cref="EventHub{TEvent}"/> for <see cref="UserOrderEvent"/>s.
        /// </summary>
        public virtual IEventHub<UserOrderEvent> UserOrderHub =>
            userOrderHub ??= new UserOrderHub(hubConnection);

        /// <summary>
        /// Gets an <see cref="EventHub{TEvent}"/> for <see cref="UserPositionEvent"/>s.
        /// </summary>
        public virtual IEventHub<UserPositionEvent> UserPositionHub =>
            userPositionHub ??= new UserPositionHub(hubConnection);

        /// <summary>
        /// Gets an <see cref="EventHub{TEvent}"/> for <see cref="UserTradeEvent"/>s.
        /// </summary>
        public virtual IEventHub<UserTradeEvent> UserTradeHub =>
            userTradeHub ??= new UserTradeHub(hubConnection);

        /// <summary>
        /// Subscribes one or more observers to <see cref="UserAccountEvent">s.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        public virtual void Subscribe(params IObserver<UserAccountEvent>[] observers) =>
            subscribers.AddRange(observers.Select(UserAccountHub.Subscribe));

        /// <summary>
        /// Subscribes one or more observers to <see cref="UserOrderEvent">.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        public virtual void Subscribe(params IObserver<UserOrderEvent>[] observers) =>
            subscribers.AddRange(observers.Select(userOrderHub.Subscribe));

        /// <summary>
        /// Subscribes one or more observers to <see cref="UserPositionEvent">.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        public virtual void Subscribe(params IObserver<UserPositionEvent>[] observers) =>
            subscribers.AddRange(observers.Select(UserPositionHub.Subscribe));

        /// <summary>
        /// Subscribes one or more observers to <see cref="UserTradeEvent">.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        public virtual void Subscribe(params IObserver<UserTradeEvent>[] observers) =>
            subscribers.AddRange(observers.Select(UserTradeHub.Subscribe));


        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    if (disposeHubConnection)
                    {
                        hubConnection?.DisposeAsync();
                    }

                    userAccountHub?.Dispose();
                    userOrderHub?.Dispose();
                    userPositionHub?.Dispose();
                    userTradeHub?.Dispose();
                }
                isDisposed = true;
            }
        }

        /// <summary>
        /// Disposes the resources used by the <see cref="UserHub"/> class.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}