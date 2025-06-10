using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using Spike.ProjectX.Api.Models.MarketData;
using Spike.ProjectX.Api.Utility;
using System;

namespace Spike.ProjectX.Api.Events
{
    /// <summary>
    /// Represents a hub for market events such as quotes, trades, and depth updates.
    /// </summary>
    public class MarketHub : IDisposable, IMarketHub
    {
        protected List<IDisposable> subscribers = new();

        protected IEventHub<MarketQuoteEvent> marketQuoteHub;
        protected IEventHub<MarketTradeEvent> marketTradeHub;
        protected IEventHub<MarketDepthEvent> marketDepthHub;

        protected HubConnection hubConnection;
        protected readonly AuthTokenHandler authTokenHandler;
        protected ProjectXSettings? projectXSettings;
        protected bool isDisposed;

        private bool disposeHubConnection = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarketHub"/> class.
        /// </summary>
        /// <param name="projectXSettings">The ProjectX settings.</param>
        public MarketHub(AuthTokenHandler handler, IOptions<ProjectXSettings> projectXSettings)
        {
            projectXSettings = Guard.NotNull(projectXSettings, nameof(projectXSettings));

            handler = Guard.NotNull(handler, nameof(handler));
            hubConnection = new HubConnectionBuilder()
                .WithUrl($"{projectXSettings.Value.MarketHubUrl}?access_token={handler.GetToken().Result}")
                .WithAutomaticReconnect()
                .Build();

            disposeHubConnection = true;
        }

        /// <summary>
        /// Starts the <see cref="MarketHub"/>.
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
        /// Gets the market quote event hub.
        /// </summary>
        public IEventHub<MarketQuoteEvent> MarketQuoteHub =>
            marketQuoteHub ??= new MarketQuoteHub(hubConnection);

        /// <summary>
        /// Gets the market trade event hub.
        /// </summary>
        public IEventHub<MarketTradeEvent> MarketTradeHub =>
            marketTradeHub ??= new MarketTradeHub(hubConnection);

        /// <summary>
        /// Gets the market depth event hub.
        /// </summary>
        public IEventHub<MarketDepthEvent> MarketDepthHub =>
            marketDepthHub ??= new MarketDepthHub(hubConnection);

        /// <summary>
        /// Subscribes one or more observers to <see cref="MarketDepthHub">.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        public virtual void Subscribe(params IObserver<MarketDepthEvent>[] observers) =>
            subscribers.AddRange(observers.Select(MarketDepthHub.Subscribe));

        /// <summary>
        /// Subscribes one or more observers to <see cref="MarketQuoteEvent">.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        public virtual void Subscribe(params IObserver<MarketQuoteEvent>[] observers) =>
            subscribers.AddRange(observers.Select(MarketQuoteHub.Subscribe));

        /// <summary>
        /// Subscribes one or more observers to <see cref="MarketTradeEvent">.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        public virtual void Subscribe(params IObserver<MarketTradeEvent>[] observers) =>
            subscribers.AddRange(observers.Select(MarketTradeHub.Subscribe));

        /// <summary>
        /// Disposes the resources used by the <see cref="MarketHub"/> class.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    if (disposeHubConnection)
                    {
                        hubConnection.DisposeAsync();
                    }

                    marketDepthHub?.Dispose();
                    marketTradeHub?.Dispose();
                    marketQuoteHub?.Dispose();
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