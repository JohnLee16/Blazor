using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


namespace BlazorServer.Data
{
    public class HttpBufferAPI : IHttpBufferAPI
    {
        private HttpClient _httpClient;
        private AacQCWebSettings _settings;

        public HttpBufferAPI(IOptions<AacQCWebSettings> settings)
        {
            _settings = settings.Value;
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
            using (var response = _httpClient.GetAsync("/api/v1/Buffer/ReadAllBufferStationStatus").GetAwaiter().GetResult())
            {
                if (response.IsSuccessStatusCode)
                {
                    var bufferStatus = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var bufferStatusReturn = JsonConvert.DeserializeObject<List<bool>>(bufferStatus);
                    return bufferStatusReturn;
                }
                else
                {
                    throw new Exception("Cannot get buffer status from manager!");
                }
            }
        }

        public List<string> GetBufferAsset()
        {
            List<string> asset = new List<string>();
            return asset;
        }
    }
}
