using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDemo.ServiceContract;
using ServiceDemo.ServiceContract.Model;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace ServiceDemo.Service
{
    public class DemoService : IDemoService
    {
        private IDemoEventService _demoEventService;

        public DemoService(IDemoEventService demoEventService)
        {
            _demoEventService = demoEventService;
        }

        async public Task<string> DemoMethod(string serviceParam, int serviceWait, int eventWait)
        {
            return await Task.Run(() =>
                {
                    var timer = new System.Threading.Timer(TimerCallback, serviceParam, eventWait, System.Threading.Timeout.Infinite);

                    System.Threading.Thread.Sleep(serviceWait);

                    return "Event queued for " + eventWait + " milliseconds";
                });
        }

        void TimerCallback(object state)
        {
            _demoEventService.DemoEvent(new EventState("Event fired with parameter " + (string)state));
        }
    }
}
