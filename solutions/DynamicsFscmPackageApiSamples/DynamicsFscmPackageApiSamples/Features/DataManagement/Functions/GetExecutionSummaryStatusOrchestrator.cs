using DynamicsFscmPackageApiSamples.Features.DataManagement.Models;
using DynamicsFscmPackageApiSamples.Services.DataManagement.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicsFscmPackageApiSamples.Features.DataManagement.Functions
{
    public static class GetExecutionSummaryStatusOrchestrator
    {
        [FunctionName(nameof(GetExecutionSummaryStatusOrchestrator))]
        public static async Task Run(
            [OrchestrationTrigger] IDurableOrchestrationContext context,
            ILogger log)
        {
            log = context.CreateReplaySafeLogger(log);

            var req = context.GetInput<GetExecutionSummaryStatusOrchestratorRequest>();
            var res = await context.CallActivityAsync<GetExecutionSummaryStatusResponse>(nameof(GetExecutionSummaryStatusActivity), req.Request);

            if (res.Value < DMFExecutionSummaryStatus.Succeeded)
            {
                var nextRun = context.CurrentUtcDateTime.AddSeconds(req.RetryInterval);

                await context.CreateTimer(nextRun, CancellationToken.None);
                context.ContinueAsNew(req);
            }
            else
            {
                if (res.Value != DMFExecutionSummaryStatus.Succeeded)
                {
                    throw new DmfJobExecutionException($"DMF job execution {res.Value}", req.Request.ExecutionId);
                }
            }
        }
    }
}
