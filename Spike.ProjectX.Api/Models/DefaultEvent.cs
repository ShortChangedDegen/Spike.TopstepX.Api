namespace Spike.ProjectX.Api.Models
{
    /// <summary>
    /// A default event.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public record DefaultEvent<T> : IEvent
        where T : new()
    {
        /// <summary>
        /// The event action.
        /// </summary>
        /// <remarks>Needs to be an enum.</remarks>
        public int Action { get; set; } // 0 = Add, 1 = Update, 2 = Delete ??????
        /// <summary>
        /// The payload.
        /// </summary>
        public T Data { get; set; } = new T();
    }
}