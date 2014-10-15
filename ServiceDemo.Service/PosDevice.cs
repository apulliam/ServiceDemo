using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Samples.Service;
using Microsoft.PointOfService;

namespace Microsoft.Samples.Server.Service
{
    public class PosDevice : IPosDevice
    {
        
        internal Microsoft.PointOfService.PosDevice InternalPosDevice { get; set; }

      
        internal PosDevice(Microsoft.PointOfService.PosDevice posDevice)
        {
            InternalPosDevice = posDevice;
        }


        public DeviceCompatibilities Compatibility
        {
            get
            {
                return InternalPosDevice.Compatibility;
            }
        }

    }
}
