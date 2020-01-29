using Microsoft.AspNetCore.SignalR.Client;
using Najdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Najdah.Services
{
    public class ReportingService
    {
        private HubConnection _connection;

        public bool IsConnected { get; private set; }


        public ReportingService(string host = "http://10.0.2.2:5000")
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(host + "/EmergencyHub")
                .WithAutomaticReconnect()
                .Build();
        }

        public async Task ConnectAsync()
        {
            if (_connection.State == HubConnectionState.Disconnected)
            {
                await _connection.StartAsync();
            }

        }

        public async Task Send(Person person, Report report)
        {
            await _connection.SendAsync("ReportEmergency", person, report);
        }
    }
}
