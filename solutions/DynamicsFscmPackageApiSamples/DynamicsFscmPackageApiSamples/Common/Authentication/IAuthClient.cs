using System.Threading;
using System.Threading.Tasks;

namespace DynamicsFscmPackageApiSamples.Common.Authentication
{
    public interface IAuthClient
    {
        Task<string> AcquireTokenForClient(CancellationToken cancellationToken);
    }
}
