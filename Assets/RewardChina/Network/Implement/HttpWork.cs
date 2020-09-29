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
        public Task<byte[]> GetBytes(string url)
        {
            var resp = client.GetAsync(url);
            return resp.Result.Content.ReadAsByteArrayAsync();
        }

        public Task<string> GetStr(string url)
        {
            var resp = client.GetAsync(url);
            return resp.Result.Content.ReadAsStringAsync();
        }

        public Task<byte[]> PostBytes(string url, string data)
        {
            var resp = client.PostAsync(url, new StringContent(data));
            return resp.Result.Content.ReadAsByteArrayAsync();
        }

        public Task<string> PostStr(string url, string data)
        {
            var m = new StringContent(data,System.Text.Encoding.UTF8, "application/json");
            var resp = client.PostAsync(url,m);
            return resp.Result.Content.ReadAsStringAsync();
        }
    }
}

