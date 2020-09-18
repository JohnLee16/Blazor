using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace BlazorServer
{
    public class AacQCWebSettings
    {
        public string AacBufferHostStation { get; set; }
        public string DigitalTwinHostStation { get; set; }
        public string AacQcManagerHostStation { get; set; }
        public string AacQcControllerHostStation { get; set; }

    }
}
