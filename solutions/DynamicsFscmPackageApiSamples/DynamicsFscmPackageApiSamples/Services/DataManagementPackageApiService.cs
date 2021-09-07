using DynamicsFscmPackageApiSamples.Services.Common.Clients;
using DynamicsFscmPackageApiSamples.Services.DataManagement.Models;
using System.Threading.Tasks;

namespace DynamicsFscmPackageApiSamples.Services
{
    public class DataManagementPackageApiService : IDataManagementPackageApiService
    {
        private const string PackageApi = "data/DataManagementDefinitionGroups/Microsoft.Dynamics.DataEntities.";

        private readonly IDynamicsFscmApiClient _client;

        public DataManagementPackageApiService(IDynamicsFscmApiClient client)
        {
            _client = client;
        }

        public Task<GetExecutionSummaryStatusResponse> GetExecutionSummaryStatus(GetExecutionSummaryStatusRequest request)
        {
            return _client.PostAsync<GetExecutionSummaryStatusRequest, GetExecutionSummaryStatusResponse>($"{PackageApi}{nameof(GetExecutionSummaryStatus)}", request);
        }
    }
}
