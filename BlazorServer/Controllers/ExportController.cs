using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Chilkat;
using CsvHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public ExportController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            var stream = new MemoryStream();
        }

        //[HttpGet]
        //public IActionResult DownloadExcel()
        //{
        //    //byte[] reportBytes;

        //    //using (var package = Utils.createExcelPackage(_hostingEnvironment))
        //    //{
        //    //    reportBytes = package.GetAsByteArray();
        //    //}

        //    //return File(reportBytes, XlsxContentType, $"MyReport{DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}.xlsx");
        //}
    }
}
