using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Models
{
    public class RelocatedSliceModel
    {
        public List<string> RemakePassedSliceId { get; set; }
        public string ProductId { get; set; }
        public string StationId { get; set; }
        public string TrayId { get; set; }
    }
}
