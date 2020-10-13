using System.Collections.Generic;
using System.Net.Http;
using BlazorServer.Models;

namespace BlazorServer.Data
{
    public interface IHttpControllerAPI
    {
        HttpClient ApiClient { get; }
        List<AacQcCheckData> GetQCControllerData(string hours);
        string GetQCControllerGreencake();
        void SendRelocateIntegrationEvent(RelocatedSliceModel relocatedSliceModel);
        void SendToBufferIntegrationEvent(SendBufferModel sendBufferModel);
    }
}