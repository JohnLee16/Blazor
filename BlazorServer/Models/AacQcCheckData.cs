using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Models
{
    public class AacQcCheckData
    {
        public Guid _id { get; set; }
        public string GreencakeId { get; set; }
        public string ProductId { get; set; }
        public string TrayId { get; set; }
        public List<SlicesQcModel> Slices { get; set; }
        public List<bool> CheckResult { get; set; }
        public DateTime AacQcTime { get; set; }
    }

    public class SlicesQcModel
    {
        public string slicesId { get; set; }
        public string wallId { get; set; }
        public int sliceThickness { get; set; }
        public int startThicknessOnTray { get; set; }
        public bool qcResult { get; set; }
        public bool hasBeenQcChecked { get; set; }
        public string parentId { get; set; }
        public bool hasBeenRemake { get; set; }
        public int remakeTimeCount { get; set; }
    }
}
