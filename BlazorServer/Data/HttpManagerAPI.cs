using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BlazorServer.Data
{
    public class HttpManagerAPI : IHttpManagerAPI
    {
        private HttpClient _httpClient;
        private AacQCWebSettings _settings;

        public HttpManagerAPI(IOptions<AacQCWebSettings> settings)
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
            var aacManagerAddress = _settings.AacQcManagerHostStation ?? "http://localhost:5001";
            _httpClient.BaseAddress = new Uri(aacManagerAddress);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        public List<bool> GetBufferRepositoryStatus()
        {
            using (var response = _httpClient.GetAsync("/api/v1/BufferStation/GetBufferRepositoryStatus").GetAwaiter().GetResult())
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

        public List<bool> GetQCSliceData()
        {
            using (var response = _httpClient.GetAsync("/api/v1/BufferStation/GetBufferRepositoryStatus").GetAwaiter().GetResult())
            {
                if (response.IsSuccessStatusCode)
                {
                    var bufferStatus = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var bufferStatusRRR = JsonConvert.DeserializeObject<List<bool>>(bufferStatus);
                    return bufferStatusRRR;
                }
                else
                {
                    throw new Exception("Cannot get buffer status from manager!");
                }
            }
        }
    }
}
