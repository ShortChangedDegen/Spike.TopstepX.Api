using Spike.ProjectX.Api.Events;
using Spike.ProjectX.Api.Models.Account;
using Spike.ProjectX.Api.Models.MarketData;
using Spike.ProjectX.Api.Models.Orders;
using Spike.ProjectX.Api.Models.Positions;
using Spike.ProjectX.Api.Models.Trades;

namespace Spike.ProjectX.Api
{
    public interface IProjectXHub
    {
        MarketEventDispatcher MarketHub { get; }
        UserEventDispatcher UserHub { get; }

        void Dispose();
        void Subscribe(params IObserver<MarketDepthEvent>[] observers);
        void Subscribe(params IObserver<MarketQuoteEvent>[] observers);
        void Subscribe(params IObserver<MarketTradeEvent>[] observers);
        void Subscribe(params IObserver<UserAccountEvent>[] observers);
        void Subscribe(params IObserver<UserOrderEvent>[] observers);
        void Subscribe(params IObserver<UserPositionEvent>[] observers);
        void Subscribe(params IObserver<UserTradeEvent>[] observers);
    }
}