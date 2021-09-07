using Microsoft.Identity.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicsFscmPackageApiSamples.Common.Authentication
{
    public class AuthClient : IAuthClient
    {
        private readonly AuthOptions _authOptions;
        private readonly IConfidentialClientApplication _clientApp;

        public AuthClient(AuthOptions apiAuthOptions)
        {
            _authOptions = apiAuthOptions;
            _clientApp = ConfidentialClientApplicationBuilder.Create(_authOptions.ClientId)
                .WithClientSecret(_authOptions.ClientSecret)
                .WithAuthority(new Uri(_authOptions.Authority))
                .Build();
        }

        public async Task<string> AcquireTokenForClient(CancellationToken cancellationToken)
        {
            string[] scopes = new string[] { _authOptions.Scope };

            AuthenticationResult authResult = await _clientApp
                .AcquireTokenForClient(scopes)
                .ExecuteAsync(cancellationToken);

            return authResult.AccessToken;
        }
    }
}
