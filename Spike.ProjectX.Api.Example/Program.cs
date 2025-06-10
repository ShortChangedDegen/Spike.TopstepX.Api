using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spike.ProjectX.Api.Events;
using Spike.ProjectX.Api.Example.Subscribers;
using Spike.ProjectX.Api.Models.Account;
using Spike.ProjectX.Api.Models.MarketData;
using Spike.ProjectX.Api.Utility;

namespace Spike.ProjectX.Api.Example
{
    internal class Program
    {
        private static IUserHub _userHub;
        private static IMarketHub _marketHub;

        private static IProjectXApi _projectXApi;

        private static async Task Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)                
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) =>
                {
                    services.Configure<ProjectXSettings>(opts => context.Configuration.GetSection("ProjectX").Bind(opts));
                    services.AddSingleton<IUserHub, UserHub>();
                    services.AddSingleton<IMarketHub, MarketHub>();
                    services.AddSingleton<IProjectXApi, ProjectXApi>();
                    services.AddSingleton<IProjectXHub, ProjectXHub>();
                    services.AddSingleton<AuthTokenHandler>();
                });
            

            var app = builder.Build();                      


            try
            {
                var _tokenStore = app.Services.GetService<AuthTokenHandler>();
                var _token = await _tokenStore.GetToken();
                _projectXApi = app.Services.GetService<IProjectXApi>();

                Console.WriteLine("Accounts:");
                var accounts = await GetAccounts();
                
                accounts = accounts.Where(x => x.Name.StartsWith("PRACTICE", StringComparison.InvariantCultureIgnoreCase)).ToList();
                accounts.ForEach(x => Console.WriteLine($"{x.Id} - {x.Name}"));
                if (!accounts?.Any() ?? false)
                {
                    Console.WriteLine("No accounts found");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Contracts:");
                var contracts = await GetContracts();
                contracts.ForEach(x => Console.WriteLine($"{x.Id} - {x.Name}, {x.Description}"));

                _userHub = app.Services.GetService<IUserHub>();
                _marketHub = app.Services.GetService<IMarketHub>();                

                await _userHub.StartAsync(); 
                await _marketHub.StartAsync();


                _userHub.Subscribe(new UserAccountObserver());
                _marketHub.Subscribe(new MarketQuoteObserver());

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }

        private static async Task<List<Account>> GetAccounts(CancellationToken cancellationToken = default)
        {
            var result = await _projectXApi.Accounts.SearchAccounts(
                new AccountSearchRequest
                {
                    OnlyActiveAccounts = true
                });

            if (!result.Success)
            {
                Console.WriteLine($"Error Connecting: {result.ErrorCode} - {result.ErrorMessage}");
            }

            return result.Accounts;
        }

        private static async Task<List<Contract>> GetContracts(CancellationToken cancellationToken = default)
        {
            var response = string.Empty;

            var result = await _projectXApi.MarketData.GetContracts(
                new ContractSearchRequest
                {
                    Live = false
                });

            if (!result.Success)
            {
                Console.WriteLine($"Error Connecting: {result.ErrorCode} - {result.ErrorMessage}");
            }

            return result.Contracts;
        }

        private static async Task StartMarketHub(List<Contract> contracts)
        {
            await _marketHub.StartAsync();
            

            //do
            //{
            //    await Task.Delay(1000);
            //    if (_marketHub.State != HubConnectionState.Connected)
            //    {
            //        if (_marketHub.State == HubConnectionState.Disconnected)
            //        {
            //            Console.WriteLine($"Connected Market Hub - Disconnected. Stopping.");
            //            await _marketHub.StopAsync();
            //            await StartMarketHub(contracts);
            //        }
            //        Console.WriteLine($"Connecting Market Hub - State:{_marketHub.State}, Connection: {_marketHub.ConnectionId}");
            //    }
            //    else if (string.IsNullOrEmpty(_marketHub.ConnectionId))
            //    {
            //        Console.WriteLine($"Connected Market Hub - No Connection ID");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Connected Market Hub - Connection: {_marketHub.ConnectionId}");


            //        // From example in docs.
            //        _marketHub.On<string, MarketQuoteEvent>("GatewayQuote", (id, data) => { Console.WriteLine($"Receive Market Quote {id}: {data}"); });
            //        Console.WriteLine($"Set Receive Market Quote");
            //        _marketHub.On<string, MarketTradeEvent[]>("GatewayTrade", (id, data) => { Console.WriteLine($"Receive Market Trades {id} ({data.Length}): {data[0]}"); });
            //        Console.WriteLine($"Set Receive Market Trade");
            //        _marketHub.On<string, MarketDepthEvent[]>("GatewayDepth", (id, data) => { Console.WriteLine($"Receive Market Depth {id} ({data.Length}):\n{data[0]}"); });
            //        Console.WriteLine($"Set Receive Depth");

            //        contracts.ForEach(async (contract) =>
            //        {
            //            bool subscribedQuotes = false;
            //            bool subscribedTrades = false;
            //            bool subscribedDepth = false;

            //            do
            //            {
            //                try
            //                {
            //                    if (!subscribedQuotes)
            //                    {
            //                        await _marketHub.InvokeAsync("SubscribeContractQuotes", contract.Id);
            //                        subscribedQuotes = true;
            //                    }
            //                }
            //                catch (Exception ex)
            //                {
            //                    Console.WriteLine($"Error Subscribing to Contract Quotes: {contract.Id} - {ex.Message}");

            //                }
            //                // From example in docs.
            //                try
            //                {
            //                    if (!subscribedTrades)
            //                    {
            //                        await _marketHub.InvokeAsync("SubscribeContractTrades", contract.Id);
            //                        subscribedTrades = true;
            //                    }
            //                }
            //                catch (Exception ex)
            //                {
            //                    Console.WriteLine($"Error Subscribing to Contract Trades: {contract.Id} - {ex.Message}");
            //                }

            //                try
            //                {
            //                    if (!subscribedDepth)
            //                    {
            //                        await _marketHub.InvokeAsync("SubscribeContractMarketDepth", contract.Id);
            //                        subscribedDepth = true;
            //                    }
            //                }
            //                catch (Exception ex)
            //                {
            //                    Console.WriteLine($"Error Subscribing to Contract Market Depth: {contract.Id} - {ex.Message}");
            //                }

            //                Console.WriteLine($"{contract.Name} Subscriptions:\n " +
            //                $"{nameof(subscribedDepth)}: {subscribedDepth},\n " +
            //                $"{nameof(subscribedQuotes)}: {subscribedQuotes},\n " +
            //                $"{nameof(subscribedTrades)}: {subscribedTrades}");
            //            }
            //            while (!(subscribedDepth && subscribedQuotes && subscribedTrades));
            //        });                    

            //        return;
            //    }
                
            //}
            //while (true);
        }

        private static async Task StartUserHub(List<Account> accounts)
        {
            

            //do
            //{
            //    await Task.Delay(1000);
            //    if (_userHub.State != HubConnectionState.Connected)
            //    {
            //        if (_userHub.State == HubConnectionState.Disconnected)
            //        {
            //            Console.WriteLine($"Connected User Hub - Disconnected. Stopping.");
            //            await _userHub.StopAsync();
            //            await StartUserHub(accounts);
            //        }
            //        Console.WriteLine($"Connecting User Hub - State:{_userHub.State}, Connection: {_userHub.ConnectionId}");
            //    }
            //    else if (string.IsNullOrEmpty(_userHub.ConnectionId))
            //    {
            //        Console.WriteLine($"Connected User Hub - No Connection ID");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Connected User Hub - Connection: {_userHub.ConnectionId}");

            //        await _userHub.InvokeAsync("SubscribeAccounts");
            //        accounts.ForEach(async account =>
            //        {
            //            await _userHub.InvokeAsync("SubscribeOrders", account.Id);
            //            await _userHub.InvokeAsync("SubscribePositions", account.Id);
            //            await _userHub.InvokeAsync("SubscribeTrades", account.Id);
            //        });

            //        // From doc example.
            //        _userHub.On<UserAccountEvent>("GatewayUserAccount", data => { Console.WriteLine($"Receive User Account Update: {data}"); });
            //        _userHub.On<UserOrderEvent>("GatewayUserOrder", data => { Console.WriteLine($"Receive User Order Update: {data}"); });
            //        _userHub.On<UserPositionEvent>("GatewayUserPosition", data => { Console.WriteLine($"Receive User Position Update: {data}"); });
            //        _userHub.On<UserTradeEvent>("GatewayUserTrade", data => { Console.WriteLine($"Receive User Trade Update: {data}"); });

            //        return;
            //    }
            //}
            //while (true);
        }
    }
}
