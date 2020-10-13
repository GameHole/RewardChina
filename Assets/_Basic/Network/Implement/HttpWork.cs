using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System.Net;
using System.Net.Http;
namespace Refinter.Net
{
    public class HttpWork :IHttp
    {
        HttpClient client = new HttpClient();
        public async Task<byte[]> GetBytes(string url)
        {
            var resp = await client.GetAsync(url);
            return await resp.Content.ReadAsByteArrayAsync();
        }

        public async Task<string> GetStr(string url)
        {
            var resp = await client.GetAsync(url);
            return await resp.Content.ReadAsStringAsync();
        }

        public async Task<byte[]> PostBytes(string url, string data)
        {
            var resp = await client.PostAsync(url, new StringContent(data));
            return await resp.Content.ReadAsByteArrayAsync();
        }

        public async Task<string> PostStr(string url, string data)
        {
            var m = new StringContent(data,System.Text.Encoding.UTF8, "application/json");
            var resp = await client.PostAsync(url,m);
            return await resp.Content.ReadAsStringAsync();
        }
    }
}

