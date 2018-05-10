using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCallingAuthenticatedAzureFunction
{
    public class TokenHelper
    {
        static string AuthUrl = "https://login.windows.net";
        /// <summary>
        /// This method gets the access tokens from AAD
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetAppOnlyAccessToken(string domain, string resourceUrl, string clientId, string clientSecret)
        {

            string authority = $"{AuthUrl}/{domain}/oauth2/token";
            var authContext = new AuthenticationContext(authority);
            // Config for OAuth client credentials 
            var clientCred = new ClientCredential(clientId, clientSecret);
            AuthenticationResult authenticationResult = await authContext.AcquireTokenAsync(resourceUrl, clientCred);
            //get access token
            return authenticationResult.AccessToken;
        }

    }
}
