using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace testapi
{
    public static class PaintsStorage
    {
        private static string getUrl = "http://interview.agileengine.com";
        private static string postUrl = "http://interview.agileengine.com/auth";
        private static string apiKey = "23567b218376f79d9415";
        private static string apiToken = "ce09287c97bf310284be3c97619158cfed026004";


        public static List<Paint> Paints { get; set;}

        public static async Task Init()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiToken);

                var responce = await httpClient.GetAsync(getUrl);
                Paints = await JsonSerializer.DeserializeAsync<List<Paint>>(await responce.Content.ReadAsStreamAsync());
            }
        }
    }
}
