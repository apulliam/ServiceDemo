using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using ServiceDemo.ServiceContract;

namespace ServiceDemo.ModernApp.Service
{
    public class DemoServiceClient : IDemoService
    {
        private string serviceUrl = "http://localhost:9000/demoservice";
        //private string serviceUrl = "http://localhost:54397/demoservice";

        public string ServiceUrl
        {
            get
            {
                return serviceUrl;
            }
            set
            {
                serviceUrl = value;
            }
        }


        async public Task<string> DemoMethod(string serviceParam, int serviceWait, int eventWait)
        {
            string url = String.Format(CultureInfo.InvariantCulture, "{0}/demomethod?serviceParam={1}&serviceWait={2}&eventWait={3}", ServiceUrl, serviceParam, serviceWait, eventWait);
            using (var demoServiceClient = new HttpClient())
            {
                var serviceReply = await demoServiceClient.GetAsync(url);
                serviceReply.EnsureSuccessStatusCode();
                return await serviceReply.Content.ReadAsAsync<string>();
            }
        }
    }
}
