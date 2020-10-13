using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using BlazorServer.Models;
using Chilkat;
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
                    throw new Exception("Cannot get slice status from controller!");
                }
            }
        }

        public string GetQCControllerGreencake()
        {
            using (var response = _httpClient.GetAsync("/api/v1/AacQcProducts/GetQcGreencakeId").GetAwaiter().GetResult())
            {
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();                    
                }
                else
                {
                    throw new Exception("Cannot get greencakeId from controller!");
                }
            }
        }

        public async void SendRelocateIntegrationEvent(RelocatedSliceModel relocatedSliceModel)
        {
            var response = await _httpClient.PostAsJsonAsync<RelocatedSliceModel>("/api/v1/AacQcProducts/RelocateIntegrationEventPublish", relocatedSliceModel);
            return;
        }

        public async void SendToBufferIntegrationEvent(SendBufferModel sendBufferModel)
        {
            var response = await _httpClient.PostAsJsonAsync<SendBufferModel>("/api/v1/AacQcProducts/SendToBufferIntegrationEventPublish", sendBufferModel);
            return;
        }
    }
}
