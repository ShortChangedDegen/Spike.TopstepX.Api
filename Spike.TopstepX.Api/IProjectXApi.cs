using Spike.TopstepX.Api.ProjectX;
namespace Spike.TopstepX.Api
{
    /// <summary>
    /// Defines the interface for the TopstepX API, providing access to 
    /// various services.
    /// <remarks>
    /// It is suggested to use a dependency injection container to locate API members
    /// for more complicated applications. (I will)
    /// </remarks>
    public interface IProjectXApi
    {
        /// <summary>
        /// Gets the account management API for accessing account-related operations.
        /// </summary>
        IAccountApi Accounts { get; }
        /// <summary>
        /// Gets the market data API for accessing market data operations.
        /// </summary>
        IMarketDataApi MarketData { get; }
        /// <summary>
        /// Gets the orders API for accessing order-related operations.
        /// </summary>
        IOrdersApi Orders { get; }
        /// <summary>
        /// Gets the positions API for accessing position-related operations.
        /// </summary>
        IPositionsApi Positions { get; }
        /// <summary>
        /// Gets the trades API for accessing trade-related operations.
        /// </summary>
        ITradesApi Trades { get; }
    }
}
