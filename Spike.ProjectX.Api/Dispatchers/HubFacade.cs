using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Spike.ProjectX.Api.Events;
using Spike.ProjectX.Api.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Spike.ProjectX.Api.Dispatchers
{
    internal class HubFacade
    {
        private HubConnection _hubConnection;

        public HubFacade(HubConnection connection)
        {
            _hubConnection = Guard.NotNull(connection, nameof(connection));
        }

        public HubFacade(string hubUrl)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUrl)
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.Closed += OnClosed;
        }

        public virtual async Task OnClosed(Exception? exception)
        {
            if(exception != null)
            {
                Console.WriteLine($"Hub connection closed with error: {exception.Message}");
            }
            else if(_hubConnection.State == HubConnectionState.Disconnected)
            {
                Console.WriteLine("Hub connection closed.");
            }
        }



        public ValueTask DisposeAsync() => _hubConnection.DisposeAsync();

    }
}
