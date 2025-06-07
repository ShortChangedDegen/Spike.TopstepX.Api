using Microsoft.AspNetCore.SignalR.Client;
using Spike.TopstepX.Api.Common;
using Spike.TopstepX.Api.Models.Account;
using Spike.TopstepX.Api.Models.MarketData;
using System.Net.WebSockets;

namespace Spike.TopstepX.Api
{
    internal class Program
    {
        private const string apiEndpoint = "https://api.topstepx.com";
        private const string userEndpoint = "https://rtc.topstepx.com/hubs/user";
        private const string marketEndpoint = "https://rtc.topstepx.com/hubs/market";
        private const string userName = "<<USERNAME>>";
        private const string apiToken = "<<APIKEY>>";

        private static AuthTokenHandler? _tokenStore;
        private static string _token = string.Empty;

        private static HubConnection? _userHub;
        private static HubConnection? _marketHub;

        // Search the names, not the IDs for more uniform conventions.
        private string[] _contracts = new[] { "EP", "NQ", "YM", "GC" };

        private static async Task Main(string[] args)
        {
            try
            {
                _tokenStore = new AuthTokenHandler(userName, apiToken, apiEndpoint);
                _token = await _tokenStore.GetToken();

                Console.WriteLine("Accounts:");
                var accounts = await GetAccounts();
                accounts = accounts.Where(x => x.Name.StartsWith("PRACTICE", StringComparison.InvariantCultureIgnoreCase)).ToList();
                accounts.ForEach(x => Console.WriteLine($"{x.Id} - {x.Name}"));

                Console.WriteLine("Contracts:");
                var contracts = await GetContracts();
                contracts.ForEach(x => Console.WriteLine($"{x.Id} - {x.Name}, {x.Description}"));

                _userHub = new HubConnectionBuilder()
                .WithUrl($"{userEndpoint}?access_token={_token}")                
                .WithStatefulReconnect()
                .Build();

                _userHub.Closed += async (error) => await _userHub.StartAsync();
                _userHub.Reconnecting += (error) => { Console.WriteLine($"User Hub Reconnecting: {error}"); return Task.CompletedTask; };
                _userHub.Reconnected += (connectionId) => { Console.WriteLine($"User Hub Reconnected: {connectionId}"); return Task.CompletedTask; };
                var accountsTask = StartUserHub(accounts);

                _marketHub = new HubConnectionBuilder()
                .WithUrl($"{marketEndpoint}?access_token={_token}")
                .WithAutomaticReconnect()
                .Build();

                _marketHub.Closed += async (error) => await _marketHub.StartAsync();
                _marketHub.Reconnecting += (error) => { Console.WriteLine($"Market Hub Reconnecting: {error}"); return Task.CompletedTask; };
                _marketHub.Reconnected += (connectionId) => { Console.WriteLine($"Market Hub Reconnected: {connectionId}"); return Task.CompletedTask; };
                await StartMarketHub(contracts);

                await Task.Delay(30000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }

            Console.ReadLine();
        }

        private static async Task<List<SearchResult>> GetAccounts(CancellationToken cancellationToken = default)
        {
            var response = string.Empty;

            var result = await ProjectXApi.Instance.Accounts.SearchAccounts(
                new SearchRequest
                {
                    OnlyActiveAccounts = true
                });

            if (!result.Success)
            {
                Console.WriteLine($"Error Connecting: {result.ErrorCode} - {result.ErrorMessage}");
            }

            return result.Payload;            
        }

        private static async Task<List<Contract>> GetContracts(CancellationToken cancellationToken = default)
        {
            var response = string.Empty;

            var result = await ProjectXApi.Instance.MarketData.GetContracts(
                new ContractSearchRequest
                {
                    Live = false
                });
            
            if (!result.Success)
            {
                Console.WriteLine($"Error Connecting: {result.ErrorCode} - {result.ErrorMessage}");
            }

            return result.Payload;
        }

        private static async Task StartMarketHub(List<Contract> contracts)
        {
            await _marketHub.StartAsync();

            do
            {
                await Task.Delay(1000);
                if (_marketHub.State != HubConnectionState.Connected)
                {
                    if (_marketHub.State == HubConnectionState.Disconnected)
                    {
                        Console.WriteLine($"Connected Market Hub - Disconnected. Stopping.");
                        await _marketHub.StopAsync();
                        await StartMarketHub(contracts);
                    }
                    Console.WriteLine($"Connecting Market Hub - State:{_marketHub.State}, Connection: {_marketHub.ConnectionId}");

                    return;
                }
                else if (string.IsNullOrEmpty(_marketHub.ConnectionId))
                {
                    Console.WriteLine($"Connected Market Hub - No Connection ID");
                }
                else
                {
                    Console.WriteLine($"Connected Market Hub - Connection: {_marketHub.ConnectionId}");
                    
                    //???? - Experiment because I'm not getting events 
                    _marketHub.On<int, dynamic>("MarketData", (contractId, data) => { Console.WriteLine($"Receive Market Quote ({contractId}): {data}"); });
                    Console.WriteLine($"Set Receive Market Quote");

                    // From example in docs.
                    _marketHub.On<int, dynamic>("GatewayQuote", (contractId, data) => { Console.WriteLine($"Receive Market Quote ({contractId}): {data}"); });
                    Console.WriteLine($"Set Receive Market Quote");
                    _marketHub.On<int, dynamic>("GatewayTrade", (contractId, data) => { Console.WriteLine($"Receive Market Trades ({contractId}): {data}"); });
                    Console.WriteLine($"Set Receive Market Trade");
                    _marketHub.On<int, dynamic>("GatewayDepth", (contractId, data) => { Console.WriteLine($"Receive Market Depth ({contractId}): {data}"); });
                    Console.WriteLine($"Set Receive Depth");

                    contracts.ForEach(async (contract) =>
                    {
                        //???? - Experiment because I'm not getting events 
                        await _marketHub.SendAsync("SubscribeMarketData", new[] { contract.Id });

                        // From example in docs.
                        await _marketHub.SendAsync("SubscribeContractQuotes", new[] { contract.Id });
                        await _marketHub.SendAsync("SubscribeContractTrades", new[] { contract.Id });
                        await _marketHub.SendAsync("SubscribeContractMarketDepth", new[] { contract.Id });
                    });
                    return;
                }
            }
            while (true);
        }

        private static async Task StartUserHub(List<SearchResult> accounts)
        {
            await _userHub.StartAsync();

            do
            {
                await Task.Delay(1000);
                if (_userHub.State != HubConnectionState.Connected)
                {
                    if (_userHub.State == HubConnectionState.Disconnected)
                    {
                        Console.WriteLine($"Connected User Hub - Disconnected. Stopping.");
                        await _userHub.StopAsync();
                        await StartUserHub(accounts);
                    }
                    Console.WriteLine($"Connecting User Hub - State:{_userHub.State}, Connection: {_userHub.ConnectionId}");

                    return;
                }
                else if (string.IsNullOrEmpty(_userHub.ConnectionId))
                {
                    Console.WriteLine($"Connected User Hub - No Connection ID");
                }
                else
                {
                    Console.WriteLine($"Connected User Hub - Connection: {_userHub.ConnectionId}");

                    await _userHub.InvokeAsync("SubscribeAccounts");
                    accounts.ForEach(async account =>
                    {
                        await _userHub.SendAsync("SubscribeOrders", new[] { account.Name });
                        await _userHub.SendAsync("SubscribePositions", new[] { account.Id });
                        await _userHub.SendAsync("SubscribeTrades", new[] { account.Id });

                    });                    

                    // From doc example.
                    _userHub.On<dynamic>("GatewayUserAccount", data => { Console.WriteLine($"Receive Account Update: {data}"); });
                    _userHub.On<dynamic>("GatewayUserOrder", data => { Console.WriteLine($"Receive Account Update: {data}"); });
                    _userHub.On<dynamic>("GatewayUserPosition", data => { Console.WriteLine($"Receive Account Update: {data}"); });
                    _userHub.On<dynamic>("GatewayUserTrade", data => { Console.WriteLine($"Receive Account Update: {data}"); });

                    return;
                }
            }
            while (true);
        }
    }
}