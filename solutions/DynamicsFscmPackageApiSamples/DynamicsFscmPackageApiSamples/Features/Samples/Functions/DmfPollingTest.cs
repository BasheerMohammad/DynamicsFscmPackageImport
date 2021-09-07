using DynamicsFscmPackageApiSamples.Features.DataManagement.Functions;
using DynamicsFscmPackageApiSamples.Features.DataManagement.Models;
using DynamicsFscmPackageApiSamples.Services.DataManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DynamicsFscmPackageApiSamples.Features.Samples.Functions
{
    public static class DmfPollingTest
    {
        [FunctionName(nameof(DmfPollingTest))]
        public static void RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var req = context.GetInput<GetExecutionSummaryStatusRequest>();

            context.CallSubOrchestratorAsync(nameof(GetExecutionSummaryStatusOrchestrator), new GetExecutionSummaryStatusOrchestratorRequest
            {
                Request = req,
                RetryInterval = 60
            });
        }

        [FunctionName("DmfPollingTest_HttpStart")]
        public static async Task<IActionResult> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            string executionId = req.Query["ExecutionId"];
            string instanceId = await starter.StartNewAsync(nameof(DmfPollingTest), new GetExecutionSummaryStatusRequest
            {
                ExecutionId = executionId
            });

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}