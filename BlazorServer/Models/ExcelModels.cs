using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Models
{
    public class ExcelModels
    {
        public string MouldId { get; set; }
        public string WallId { get; set; }
        public string SliceId { get; set; }
        public bool QcResult { get; set; }
        public string FailureReason { get; set; }
        public DateTime QcTime { get; set; }

        public Dictionary<int, string> ColumeHeadName = new Dictionary<int, string>()
        {
            { 1, "模具Id"},
            { 2, "墙Id"},
            { 3, "砖Id"},
            { 4, "QC结果"},
            { 5, "QC时间"}
        };
    }
    
}
