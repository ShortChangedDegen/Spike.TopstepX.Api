using Microsoft.Extensions.Options;
using Spike.ProjectX.Api.Events;
using Spike.ProjectX.Api.Models.Account;
using Spike.ProjectX.Api.Models.MarketData;
using Spike.ProjectX.Api.Models.Orders;
using Spike.ProjectX.Api.Models.Positions;
using Spike.ProjectX.Api.Models.Trades;
using Spike.ProjectX.Api.Utility;

namespace Spike.ProjectX.Api
{
    /// <summary>
    /// ProjectXHub is a central hub for managing subscriptions to various market and user events.
    /// </summary>
    /// <remarks>
    /// This is an attempt to handle complexity without using dependency injection.
    /// It should be fairly easy to navigate and understand.
    /// </remarks>
    public class ProjectXHub : IDisposable, IProjectXHub
    {
        private bool _isDisposed;
        private List<IDisposable> _subscriptions = new List<IDisposable>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectXHub"/> class with the specified market and user hubs.
        /// </summary>
        /// <param name="marketHub">A market hub.</param>
        /// <param name="userHub">A user hub.</param>
        internal ProjectXHub(MarketHub marketHub, UserHub userHub)
        {
            UserHub = Guard.NotNull(userHub, nameof(userHub));
            MarketHub = Guard.NotNull(marketHub, nameof(marketHub));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectXHub"/> class with the specified settings.
        /// </summary>
        /// <param name="api">The ProjectX API.</param>
        /// <param name="settings">The ProjectX settings.</param>
        public ProjectXHub(AuthTokenHandler authTokenHandler, IOptions<ProjectXSettings> settings)
            : this(new MarketHub(authTokenHandler, settings), new UserHub(authTokenHandler, settings))
        {
        }

        /// <summary>
        /// Gets the <see cref="UserHub"/>.
        /// </summary>
        public UserHub UserHub { get; }

        /// <summary>
        /// Gets the <see cref="MarketHub"/>.
        /// </summary>
        public MarketHub MarketHub { get; }

        /// <summary>
        /// Subscribes one or more observers for <see cref="MarketQuoteEvent"/>s.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        public void Subscribe(params IObserver<MarketQuoteEvent>[] observers) =>
            _subscriptions.AddRange(observers.Select(MarketHub.MarketQuoteHub.Subscribe));

        /// <summary>
        /// Subscribes one or more observers for <see cref="MarketTradeEvent"/>s.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        public void Subscribe(params IObserver<MarketTradeEvent>[] observers) =>
            _subscriptions.AddRange(observers.Select(MarketHub.MarketTradeHub.Subscribe));

        /// <summary>
        /// Subscribes one or more observers for <see cref="MarketDepthEvent"/>s.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        public void Subscribe(params IObserver<MarketDepthEvent>[] observers) =>
            _subscriptions.AddRange(observers.Select(MarketHub.MarketDepthHub.Subscribe));

        /// <summary>
        /// Subscribes one or more observers for <see cref="UserAccountEvent"/>s.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        public void Subscribe(params IObserver<UserAccountEvent>[] observers) =>
            _subscriptions.AddRange(observers.Select(UserHub.UserAccountHub.Subscribe));

        /// <summary>
        /// Subscribes one or more observers for <see cref="UserOrderEvent"/>s.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        public void Subscribe(params IObserver<UserOrderEvent>[] observers) =>
            _subscriptions.AddRange(observers.Select(UserHub.UserOrderHub.Subscribe));

        /// <summary>
        /// Subscribes one or more observers for <see cref="UserPositionEvent"/>s.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        public void Subscribe(params IObserver<UserPositionEvent>[] observers) =>
            _subscriptions.AddRange(observers.Select(UserHub.UserPositionHub.Subscribe));

        /// <summary>
        /// Subscribes one or more observers for <see cref="UserTradeEvent"/>s.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        public void Subscribe(params IObserver<UserTradeEvent>[] observers) =>
            _subscriptions.AddRange(observers.Select(UserHub.UserTradeHub.Subscribe));

        /// <summary>
        /// Disposes the resources used by the <see cref="ProjectXHub"/> instance.
        /// </summary>
        /// <param name="disposing">Whether to clean up managed resource.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _subscriptions.ForEach(s => s.Dispose());
                }

                _isDisposed = true;
            }
        }

        /// <summary>
        /// Disposes the resources used by the <see cref="ProjectXHub"/> instance.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
