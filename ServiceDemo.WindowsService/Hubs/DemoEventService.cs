using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using ServiceDemo.ServiceContract;
using ServiceDemo.ServiceContract.Model;

namespace ServiceDemo.WindowsService.Hubs
{
    public class DemoEventService : IDemoEventService
    {
   
        async public Task DemoEvent(EventState eventState)
        {
            await Task.Run(() =>
                {
                    var hubContext = GlobalHost.ConnectionManager.GetHubContext<DemoEventHub>();
                    hubContext.Clients.All.DemoEvent(eventState);
                });
        }
    }
}
