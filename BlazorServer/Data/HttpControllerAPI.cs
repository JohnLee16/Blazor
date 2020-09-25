using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using BlazorServer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


namespace BlazorServer.Data
{
    public class HttpControllerAPI : IHttpControllerAPI
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

        public List<AacQcCheckData> GetQCControllerData(string hours)
        {
            using (var response = _httpClient.GetAsync("/api/v1/AacQcProducts/GetAllSlices/" + hours).GetAwaiter().GetResult())
            {
                if (response.IsSuccessStatusCode)
                {
                    var aacQCData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return JsonConvert.DeserializeObject<List<AacQcCheckData>>(aacQCData);
                }
                else
                {
                    throw new Exception("Cannot get slice status from manager!");
                }
            }
        }
    }
}
