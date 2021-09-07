using DynamicsFscmPackageApiSamples.Common;
using System.Net.Http;

namespace DynamicsFscmPackageApiSamples.Services.Common.Clients
{
    public class DynamicsFscmApiClient : ApiClient, IDynamicsFscmApiClient
    {
        public DynamicsFscmApiClient(HttpClient httpClient) : base(httpClient)
        {

        }
    }
}
