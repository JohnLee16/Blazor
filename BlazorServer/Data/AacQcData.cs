using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using OfficeOpenXml;

namespace BlazorServer.Data
{
    public class AacQcData
    {
        public void GenerateExcel(IJSRuntime jSRuntime)
        {
            byte[] fileContents;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells[1, 1].Value = "test";
                fileContents = package.GetAsByteArray();
            }
            jSRuntime.InvokeAsync<AacQcData>(
                "saveAsFile",
                "test.xlsx",
                Convert.ToBase64String(fileContents)
                );
        }
    }
}
