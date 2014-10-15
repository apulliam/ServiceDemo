using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDemo.ServiceContract.Model
{
    public class EventState 
    {
        public string Property1 { get; private set; }

        public EventState(string property1)
        {
            Property1 = property1;
        }
    }
}
