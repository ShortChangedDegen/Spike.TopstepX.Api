﻿namespace Spike.ProjectX.Api.Rest.Models.MarketData
{
    /// <summary>
    /// Represents a request to search for contracts in the TopstepX API.
    /// </summary>
    public record ContractSearchRequest
    {
        /// <summary>
        /// Gets or sets the the id of the contract to search for.
        /// </summary>
        public string? ContractId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the contract to search for.
        /// </summary>
        public string? SearchText { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the whether to search for contracts using the sim/live data subscription.
        /// </summary>
        public bool Live { get; set; } = true;
    }
}