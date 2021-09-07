using System.Globalization;

namespace DynamicsFscmPackageApiSamples.Common.Authentication
{
    public class AuthOptions
    {
        /// <summary>
        /// Instance of Azure AD, for example public Azure or a Sovereign cloud (Azure China, Germany, US government, etc.)
        /// </summary>
        public string Instance { get; set; } = "https://login.microsoftonline.com/{0}";

        /// <summary>
        /// The Tenant is:
        /// - either the tenant ID of the Azure AD tenant in which this application is registered (a guid)
        /// - or a domain name associated with the tenant
        /// - or 'organizations' (for a multi-tenant application)
        /// </summary>
        public string Tenant { get; set; }

        /// <summary>
        /// Guid used by the application to uniquely identify itself to Azure AD
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Client secret (application password)
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// The base url of the API
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// The scope for the API. With client credentials flow, the scopes is ALWAYS of the shape "resource/.default"
        /// </summary>
        public string Scope
        {
            get
            {
                return $"{BaseUrl}/.default";
            }
        }

        /// <summary>
        /// URL of the authority
        /// </summary>
        public string Authority
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, Instance, Tenant);
            }
        }
    }
}
