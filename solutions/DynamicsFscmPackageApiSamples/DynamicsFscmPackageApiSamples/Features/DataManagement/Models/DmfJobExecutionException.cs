using System;
using System.Runtime.Serialization;

namespace DynamicsFscmPackageApiSamples.Features.DataManagement.Models
{
    [Serializable]
    public class DmfJobExecutionException : Exception
    {
        public string ExecutionId { get; }

        public DmfJobExecutionException()
        {
        }

        public DmfJobExecutionException(string message) : base(message)
        {
        }

        public DmfJobExecutionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public DmfJobExecutionException(string message, string executionId) : this(message)
        {
            ExecutionId = executionId;
        }

        protected DmfJobExecutionException(SerializationInfo info, StreamingContext context)
        {
            ExecutionId = info.GetString(nameof(DmfJobExecutionException.ExecutionId));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(DmfJobExecutionException.ExecutionId), ExecutionId);
        }
    }
}
