using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Models
{
    public class QCSliceViewModel
    {
        public string GreencakeId { get; set; }
        public string SliceId { get; set; }
        public string QcResult { get; set; }
        public string RemakeSlice { get; set; }
        public string RemakeCount { get; set; }
        public DateTime QcTime { get; set; }
    }
}
