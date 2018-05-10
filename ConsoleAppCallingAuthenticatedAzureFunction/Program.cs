using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCallingAuthenticatedAzureFunction
{
    class Program
    {
        static  void Main(string[] args)
        {

            CallAuthenticatedAzureFunction().Wait();
            Console.ReadKey();
        }

        private static async Task CallAuthenticatedAzureFunction()
        {
            string resourceId = "<id of Azure AD app used for Azure Function authentication>";  // AAD app ID used by the Azure function for authentication
            string clientId = "<id of Azure AD app registered for the Daemon job>";// AAD app ID of your console app
            string clientSecret = "<secret of Azure AD app for Daemon job>"; // Client secret of the AAD app registered for console app
            string resourceUrl = "https://blahblah.azurewebsites.net/api/events"; //HTTP function Endpoint to get events
            string domain = "<yourtenant>.onmicrosoft.com";   //Tenant domain
            var accessToken = await TokenHelper.GetAppOnlyAccessToken(domain, resourceId, clientId, clientSecret);
            var response= await HttpRequestUtil.ExecuteRequest(HttpMethod.Get, resourceUrl, accessToken);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                Console.WriteLine("Something went wrong");
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
