using DynamicsFscmPackageApiSamples.Services.DataManagement.Models;
using System.Threading.Tasks;

namespace DynamicsFscmPackageApiSamples.Services
{
    public interface IDataManagementPackageApiService
    {
        Task<GetExecutionSummaryStatusResponse> GetExecutionSummaryStatus(GetExecutionSummaryStatusRequest request);
    }
}