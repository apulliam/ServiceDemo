using System.Web.Http;

namespace WebApiHelper
{
    public abstract class WebApiService<IService> : ApiController
    {
        protected IService InnerService
        {
            get;
            private set;
        }

        public WebApiService(IService service)
        {
            InnerService = service;
        }
    }
}

