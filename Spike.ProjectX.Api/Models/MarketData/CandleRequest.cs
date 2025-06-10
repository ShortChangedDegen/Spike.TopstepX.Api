using Spike.ProjectX.Api.Models.Orders;

namespace Spike.ProjectX.Api.Models.MarketData
{
    /// <summary>
    /// A market data candle request.
    /// </summary>
    public record CandleRequest
    {
        /// <summary>
        ///     The contract ID.
        /// </summary>
        public int? ContractId { get; set; }
        /// <summary>
        ///     Whether to retrieve bars using the sim or live data subscription.
        /// </summary>
        public bool? Live { get; set; }
        /// <summary>
        ///     The start time of the historical data.
        /// </summary>
        public bool? StartTime { get; set; }
        /// <summary>
        /// 	The end time of the historical data.
        /// </summary>
        public bool? EndTime { get; set; }
        /// <summary>
        ///     The unit of aggregation for the historical data.
        /// </summary>
        public Unit? Unit { get; set; }
        /// <summary>
        /// 	The number of units to aggregate.
        /// </summary>
        public int? UnitNumber { get; set; }
        /// <summary>
        ///     The maximum number of bars to retrieve.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// 	Whether to include a partial bar representing the current time unit.
        /// </summary>
        public bool? IncludePartialBar { get; set; }
    }
}