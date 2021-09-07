using Newtonsoft.Json;

namespace DynamicsFscmPackageApiSamples.Services.DataManagement.Models
{
    public class GetExecutionSummaryStatusResponse
    {
        [JsonProperty("value")]
        public DMFExecutionSummaryStatus Value { get; set; }
    }
}
