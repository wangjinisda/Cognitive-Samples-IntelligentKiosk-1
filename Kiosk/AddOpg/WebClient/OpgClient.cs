using IntelligentKioskSample.AddOpg.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentKioskSample.AddOpg.WebClient
{
    public class OpgClient
    {
        public string baseAddress = "http://opgwebapi.chinacloudsites.cn/";

        public HttpClient HttpClient { get; set; }

        public OpgClient()
        {
            this.HttpClient = new HttpClient();
        }

        public async Task<OpgResponseModel> SendMessageToCloud(UploadedVideoModel o)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "api/Cameras");

            using (var content = new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json"))
            {
                request.Content = content;
                var response = await HttpClient.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var outs = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<OpgResponseModel>(outs);
            }
        }
    }
}
