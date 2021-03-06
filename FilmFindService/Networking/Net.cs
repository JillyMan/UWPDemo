﻿using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FilmFindService.Networking
{
    public class NetHttp : INet
    {
        public async Task<string> GetJson(string uri)
        {
            LogingService.LoggingServices.Instance.WriteLine<NetHttp>($"Try get json from {uri}");

            string result = "";
            using (var httpClient = new HttpClient())
            {
                using (var responce = await httpClient.GetAsync(uri))
                {
                    result = await responce.Content.ReadAsStringAsync();
                }
            }

            LogingService.LoggingServices.Instance.WriteLine<NetHttp>($"Get from Uri: {uri}, Content{result}");

            return result;
        }

        public async Task<T> GetObject<T>(string uri)
        {
            string json = await GetJson(uri);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}