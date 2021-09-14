using NeverBored.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NeverBored.API
{
    public class ActivityProcessor
    {
        public static async Task<ActivityModel> LoadActivity()
        {
            string url = ApiHelper.ApiClient.BaseAddress.ToString();

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ActivityModel activity = await response.Content.ReadAsAsync<ActivityModel>();

                    return activity;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
