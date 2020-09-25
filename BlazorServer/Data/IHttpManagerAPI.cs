using System.Collections.Generic;
using System.Net.Http;

namespace BlazorServer.Data
{
    public interface IHttpManagerAPI
    {
        HttpClient ApiClient { get; }

        List<string> GetBufferAsset();
        List<bool> GetBufferRepositoryStatus();
        List<bool> GetQCSliceData();
    }
}