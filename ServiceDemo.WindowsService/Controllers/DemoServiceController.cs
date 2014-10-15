using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web.Http;
using ServiceDemo.ServiceContract;
using WebApiHelper;

namespace ServiceDemo.WindowsService.Controllers
{
    [RoutePrefix("demoservice")]
    public class DemoServiceController : WebApiService<IDemoService>, IDemoService
    {
        public DemoServiceController(IDemoService demoService)
            : base(demoService)
        {
        }

        [Route("demomethod")]
        [HttpGet]
        async public Task<string> DemoMethod(string serviceParam, int serviceWait, int eventWait)
        {
            return await InnerService.DemoMethod(serviceParam, serviceWait, eventWait);
        }

  

    }
}