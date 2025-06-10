using Spike.ProjectX.Api.Models;

namespace Spike.ProjectX.Api.Events
{
    /// <summary>
    /// Defines a contract for an event hub that can publish and
    /// subscribe to events of type <typeparamref name="TEvent"/>.
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public interface IEventHub<TEvent> : IObservable<TEvent>, IDisposable
        where TEvent : IEvent
    {
    }
}