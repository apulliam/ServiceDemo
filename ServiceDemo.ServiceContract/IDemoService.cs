using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDemo.ServiceContract
{
    public interface IDemoService 
    {
        Task<string> DemoMethod(string serviceParam, int serviceWait, int eventWait);
    }
}
