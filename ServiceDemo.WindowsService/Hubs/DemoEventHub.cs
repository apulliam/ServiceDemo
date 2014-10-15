using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using ServiceDemo.ServiceContract;
using ServiceDemo.ServiceContract.Model;

namespace ServiceDemo.WindowsService.Hubs
{
    [HubName("DemoEventHub")]
    public class DemoEventHub : Hub
    {
        public void DemoEvent(EventState eventState)
        {
            Clients.All.Event1(eventState);
        }
    }
}