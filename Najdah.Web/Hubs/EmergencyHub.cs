using Microsoft.AspNetCore.SignalR;
using Najdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Najdah.Web.Hubs
{
    public class EmergencyHub : Hub
    {
        public async Task ReportEmergency(Person person, Report report)
        {
            await Clients.All.SendAsync("ReceiveReport", person, report);
        }
    }
}
