using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicsFscmPackageApiSamples.Common.Authentication
{
    public class ApiClientBearerTokenHandler<T> : DelegatingHandler where T : IAuthClient
    {
        private readonly T _authClient;

        public ApiClientBearerTokenHandler(T authClient) : base()
        {
            _authClient = authClient ?? throw new ArgumentNullException(nameof(authClient));
        }
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var accessToken = await _authClient.AcquireTokenForClient(cancellationToken);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
