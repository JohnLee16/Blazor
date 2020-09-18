using System.Collections.Generic;
using System.Net.Http;

namespace BlazorServer.Data
{
    public interface IHttpBufferAPI
    {
        HttpClient ApiClient { get; }

        List<bool> GetBufferRealTimeStatus();
    }
}