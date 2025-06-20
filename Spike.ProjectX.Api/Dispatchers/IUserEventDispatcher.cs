using Spike.ProjectX.Api.Models.Account;
using Spike.ProjectX.Api.Models.Orders;
using Spike.ProjectX.Api.Models.Positions;
using Spike.ProjectX.Api.Models.Trades;

namespace Spike.ProjectX.Api.Events
{
    public interface IUserEventDispatcher : IDisposable
    {
        IEventDispatcher<UserAccountEvent> UserAccountHub { get; }
        IEventDispatcher<UserOrderEvent> UserOrderHub { get; }
        IEventDispatcher<UserPositionEvent> UserPositionHub { get; }
        IEventDispatcher<UserTradeEvent> UserTradeHub { get; }

        Task StartAsync();
        void Subscribe(params IObserver<UserAccountEvent>[] observers);
        void Subscribe(params IObserver<UserOrderEvent>[] observers);
        void Subscribe(params IObserver<UserPositionEvent>[] observers);
        void Subscribe(params IObserver<UserTradeEvent>[] observers);
    }
}