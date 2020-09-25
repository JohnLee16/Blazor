using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Models
{
    public class ExcelModels
    {
        public ExcelModels()
        {
        }

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
