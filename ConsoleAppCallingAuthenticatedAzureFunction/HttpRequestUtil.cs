using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCallingAuthenticatedAzureFunction
{
    public class HttpRequestUtil
    {
        public static async Task<HttpResponseMessage> ExecuteRequest(HttpMethod method,
            string url, string accessTokens)
        {
            var handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new HttpRequestMessage(method, url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessTokens);
                HttpResponseMessage result = await client.SendAsync(request);
                return result;
            }
        }
    }
}
