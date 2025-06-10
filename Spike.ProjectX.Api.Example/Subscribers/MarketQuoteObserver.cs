using Spike.ProjectX.Api.Models.MarketData;

namespace Spike.ProjectX.Api.Example.Subscribers
{
    public class MarketQuoteObserver : IObserver<MarketQuoteEvent>
    {
        public void OnCompleted(){}
        public void OnError(Exception error) => Console.WriteLine(error);
        public void OnNext(MarketQuoteEvent value) => Console.WriteLine(value);
    }
}
