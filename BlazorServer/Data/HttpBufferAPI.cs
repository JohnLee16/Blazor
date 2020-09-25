using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Threading;

namespace BlazorServer.Data
{
    public class HttpBufferAPI : IHttpBufferAPI
    {
        private HttpClient _httpClient;
        private AacQCWebSettings _settings;
        private IHttpContextAccessor _httpContext;

        public HttpBufferAPI(IOptions<AacQCWebSettings> settings, IHttpContextAccessor httpContext)
        {
            _settings = settings.Value;
            _httpContext = httpContext;
            InitializeClient();            
        }

        public HttpClient ApiClient
        {
            get
            {
                return _httpClient;
            }
        }

        private void InitializeClient()
        {
            _httpClient = new HttpClient();
            var aacBufferAddress = _settings.AacBufferHostStation ?? "http://localhost:5001";
            _httpClient.BaseAddress = new Uri(aacBufferAddress);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        public List<bool> GetBufferRealTimeStatus()
        {
            string bufferStationId = "aac_qc_buffer_station_";
            List<bool> bufferStatusReturn = new List<bool>(); 
            for (int i = 1; i <= 10; i++)
            {
                bool bufferStatusTemp;
                using (var response = _httpClient.GetAsync("/api/v1/Buffer/ReadBufferStationStatus/" + bufferStationId + i.ToString()).GetAwaiter().GetResult())
                {                    
                    if (response.IsSuccessStatusCode)
                    {
                        var bufferStatus = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        bufferStatusTemp = JsonConvert.DeserializeObject<bool>(bufferStatus);                        
                    }
                    else
                    {
                        throw new Exception("Cannot get buffer status from buffer controller!");
                    }
                }
                bufferStatusReturn.Add(bufferStatusTemp);
            }
            
            return bufferStatusReturn;
        }

        public void OutputClient(byte[] bytes)
        {
            
            HttpResponse response =  _httpContext.HttpContext.Response;
            var write = response.BodyWriter;
            

            response.Clear();
            //response.ClearHeaders();
            //response.ClearContent();

            //response.ContentType = "application/ms-excel";
            response.ContentType = "application/vnd.openxmlformats - officedocument.spreadsheetml.sheet";
            //response.AppendHeader("Content-Type", "text/html; charset=GB2312");
            //response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")));
            response.Headers.Add("Content-Disposition", string.Format("attachment; filename={0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")));
            response.Headers.Append("Content-Type", "text/html; charset=GB2312");
            //response.Charset = "GB2312";
            //response.ContentEncoding = Encoding.GetEncoding("GB2312");

            foreach (var b in bytes)
            {
                response.Body.WriteByte(b);
            }
            //AsyncCallback asyncCallback;
            //response.Body.BeginWrite(bytes, 0, int.MaxValue); //WriteAsync(textString).GetAwaiter();
            //response.BinaryWrite(bytes);
            response.Body.Flush();

            response.Body.Dispose();
        }
    }
}
