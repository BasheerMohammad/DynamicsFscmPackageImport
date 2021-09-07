using DynamicsFscmPackageApiSamples.Services.DataManagement.Models;
using System.Diagnostics.CodeAnalysis;

namespace DynamicsFscmPackageApiSamples.Features.DataManagement.Models
{
    [ExcludeFromCodeCoverage]
    public class GetExecutionSummaryStatusOrchestratorRequest
    {
        public GetExecutionSummaryStatusRequest Request { get; set; }
        public int RetryInterval { get; set; } = 60;
    }
}
