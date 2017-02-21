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
        //public string baseAddress = "http://localhost:5000/";

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


        public async Task<IEnumerable<OpgResponseModel>> SendImageAsBase64String(ImageModel o)
        {
            var returnValues = new List<OpgResponseModel>();

            OpgResponseModel first = null;
           var requestForPost = new HttpRequestMessage(HttpMethod.Post, baseAddress + "api/Cameras/image");

            using (var content = new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json"))
            {
                requestForPost.Content = content;
                var response = await HttpClient.SendAsync(requestForPost).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var outs = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                first = JsonConvert.DeserializeObject<OpgResponseModel>(outs);
                returnValues.Add(first);
            }

            if(first.MessageStatus != "Failed")
            {
                var requestForPut = new HttpRequestMessage(HttpMethod.Put, baseAddress + "api/Cameras/image");

                using (var content = new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json"))
                {
                    requestForPut.Content = content;
                    var response = await HttpClient.SendAsync(requestForPut).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                    var outs = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    returnValues.Add(JsonConvert.DeserializeObject<OpgResponseModel>(outs));
                }
            }

            return returnValues;
        }

        public async Task<OpgResponseModel> SendImageAsBase64StringForNameRegister(ImageForNameModel o)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "api/Cameras/Train");

            using (var content = new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json"))
            {
                request.Content = content;
                var response = await HttpClient.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var outs = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<OpgResponseModel>(outs);
            }
        }

        public async Task<OpgResponseModel> FacesAddToSpecificPersonGroup(ImageForNameModel o)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "api/Cameras/FacesAdd");

            using (var content = new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json"))
            {
                request.Content = content;
                var response = await HttpClient.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var outs = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<OpgResponseModel>(outs);
            }
        }


        public async Task<OpgResponseModel> GroupCreation(string o)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "api/Cameras/GroupCreation");

            using (var content = new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json"))
            {
                request.Content = content;
                var response = await HttpClient.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var outs = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<OpgResponseModel>(outs);
            }
        }

        public async Task<OpgResponseModel> PersonGroupTrain(string o)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "api/Cameras/Train");

            using (var content = new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json"))
            {
                request.Content = content;
                var response = await HttpClient.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var outs = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<OpgResponseModel>(outs);
            }
        }

        public async Task<OpgResponseModel> CameraRegister(string name)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, baseAddress + "api/Cameras/Register/" + name);

            using (var content = new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"))
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
