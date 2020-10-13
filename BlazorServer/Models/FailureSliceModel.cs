using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Models
{
    public class FailureSliceModel
    {
        public Dictionary<string, string> FailureInfos { get; set; }
        public List<FailureInfo> failureInfos { get; set; }
    }

    
    public class FailureInfo
    {
        public string SliceId { get; set; }
        public string FailureSliceInfo { get; set; }
    }
}
