using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FilmFindService.NetwokLayer
{
    public class Net
    {
        public async Task<string> GetJson(string url)
        {
            string result = "";
            using (var httpClient = new HttpClient())
            {
                using (var responce = await httpClient.GetAsync(url))
                {
                    result = await responce.Content.ReadAsStringAsync();
                }
            }
            return result;
        }

        public async Task<byte[]> GetBytes(string url)
        {
            byte[] result;
            using (var httpClient = new HttpClient())
            {
                using (var responce = await httpClient.GetAsync(url))
                {
                    result = await responce.Content.ReadAsByteArrayAsync();
                }
            }
            return result;
        }
    }
}