using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


namespace BlazorServer.Data
{
    public class HttpControllerAPI
    {
        private HttpClient _httpClient;
        private AacQCWebSettings _settings;

        public HttpControllerAPI(IOptions<AacQCWebSettings> settings)
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
            var aacControllerAddress = _settings.AacQcControllerHostStation ?? "http://localhost:6001";
            _httpClient.BaseAddress = new Uri(aacControllerAddress);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        public List<bool> GetQCControllerData()
        {
            using (var response = _httpClient.GetAsync("/api/v1/AacQcController/GetBufferRepositoryStatus").GetAwaiter().GetResult())
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
    }
}
