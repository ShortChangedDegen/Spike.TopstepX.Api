using Spike.ProjectX.Api.Models.MarketData;

namespace Spike.ProjectX.Api.Events
{
    public interface IMarketEventDispatcher : IDisposable
    {
        IEventDispatcher<MarketDepthEvent> MarketDepthHub { get; }
        IEventDispatcher<MarketQuoteEvent> MarketQuoteHub { get; }
        IEventDispatcher<MarketTradeEvent> MarketTradeHub { get; }

        /// <summary>
        /// Subscribes one or more observers to <see cref="MarketDepthHub">.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        void Subscribe(params IObserver<MarketDepthEvent>[] observers);

        /// <summary>
        /// Subscribes one or more observers to <see cref="MarketQuoteEvent">.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        void Subscribe(params IObserver<MarketQuoteEvent>[] observers);

        /// <summary>
        /// Subscribes one or more observers to <see cref="MarketTradeEvent">.
        /// </summary>
        /// <param name="observers">One or more observers.</param>
        void Subscribe(params IObserver<MarketTradeEvent>[] observers);

        Task StartAsync();
    }
}