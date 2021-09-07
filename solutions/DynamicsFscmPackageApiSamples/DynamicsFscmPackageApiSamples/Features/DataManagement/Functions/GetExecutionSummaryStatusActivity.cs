using DynamicsFscmPackageApiSamples.Services;
using DynamicsFscmPackageApiSamples.Services.DataManagement.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System;
using System.Threading.Tasks;

namespace DynamicsFscmPackageApiSamples.Features.DataManagement.Functions
{
    public class GetExecutionSummaryStatusActivity
    {
        private readonly IDataManagementPackageApiService _service;

        public GetExecutionSummaryStatusActivity(IDataManagementPackageApiService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [FunctionName(nameof(GetExecutionSummaryStatusActivity))]
        public async Task<GetExecutionSummaryStatusResponse> Run(
            [ActivityTrigger] GetExecutionSummaryStatusRequest req)
        {
            var response = await _service.GetExecutionSummaryStatus(req);

            return response;
        }
    }
}
