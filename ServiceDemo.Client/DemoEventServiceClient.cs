using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceDemo.ServiceContract;
using ServiceDemo.ServiceContract.Model;
using Microsoft.AspNet.SignalR.Client;
using SignalRHelper;

namespace ServiceDemo.Client
{
    public class DemoEventServiceClient : EventServiceClient<IDemoEventService>, IDemoEventService
    {
        public DemoEventServiceClient(IDemoEventService demoEventService)
            : base(demoEventService, "DemoEventHub")
        {
            ServerAddress = "http://localhost:9000";
            //ServerAddress = "http://localhost:54397";
            HubProxy.On<EventState>("DemoEvent", async eventState => await DemoEvent(eventState));  
        }

        async public Task DemoEvent(EventState eventState)
        {
            await InnerClient.DemoEvent(eventState);
        }
    }
}
