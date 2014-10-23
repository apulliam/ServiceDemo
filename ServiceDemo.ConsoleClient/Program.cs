using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDemo.ServiceContract;
using ServiceDemo.Client;

namespace ServiceDemo.ConsoleClient
{
    public class Program : IDemoEventService
    {
        static void Main(string[] args)
        {
            var serviceParam = "Test";
            var serviceDelay = 1000;
            var eventDelay = 5000;
            var program = new Program();
            program.Run(serviceParam, serviceDelay, eventDelay);
        }

        public void Run(string serviceParam, int serviceDelay, int eventDelay)
        {
            var demoEventServiceClient = new DemoEventServiceClient(this);
            demoEventServiceClient.Start().Wait();
            Console.WriteLine(string.Format("Started DemoEventServiceClient at {0}", DateTime.Now));

            var demoServiceClient = new DemoServiceClient();
            Console.WriteLine(string.Format("Calling EventService.DemoMethod with seviceParam={0}, serviceWait={1}, eventWait={2} at {3}", serviceParam, serviceDelay, eventDelay, DateTime.Now));
            var response = demoServiceClient.DemoMethod(serviceParam, serviceDelay, eventDelay).Result;
            Console.WriteLine(string.Format("EventService.DemoMethod returned {0} at {1}", response, DateTime.Now));
            
            Console.WriteLine("Use Ctrl-C to exit\n");

            while (true)
            {
            }
        }

        public Task DemoEvent(ServiceContract.Model.EventState eventState)
        {
            return Task.Run(()=>
                {
                    Console.WriteLine(string.Format("DemoEventService.DemoEvent called with {0} at {1}", eventState.Property1, DateTime.Now));
                });
        }
    }
}
