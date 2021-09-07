using Newtonsoft.Json;

namespace DynamicsFscmPackageApiSamples.Services.DataManagement.Models
{
    public class GetExecutionSummaryStatusRequest
    {
        [JsonProperty("executionId")]
        public string ExecutionId { get; set; }
    }
}
