using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NeverBored.API
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("http://www.boredapi.com/api/activity");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
