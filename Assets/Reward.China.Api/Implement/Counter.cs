using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace Reward.China
{
    public class Counter : ICounter
    {
        INetInfo info;
        IHttp http;
        IUrlApi Url;
        IMsgLog log;
        public async Task<int> GetCount(int id, int defaultV = 0)
        {
            var send = new JObject();
            send.Add("moveId", id);
            if (!string.IsNullOrEmpty(info.openid))
                send.Add("openId", info.openid);
            send.Add("game", info.package);
            send.Add("deviceId", info.deviceId);
            //Debug.Log(Url.getApi("counter_get"));
            log?.Log(send);
            var recv = JsonConvert.DeserializeObject<JObject>(await http.PostStr(Url.getApi("counter_get"), send.ToString()));
            log?.Log(recv);
            int code = recv.Value<int>("code");
            if (code == 200)
            {
                return recv["data"].Value<int>("count");
            }
            return defaultV;
        }

        public async Task<bool> Increment(int id)
        {
            var send = new JObject();
            send.Add("moveId", id);
            if(!string.IsNullOrEmpty(info.openid))
                send.Add("openId", info.openid);
            send.Add("game", info.package);
            send.Add("deviceId", info.deviceId);
            log?.Log(send);
            var recv = JsonConvert.DeserializeObject<JObject>(await http.PostStr(Url.getApi("counter_inc"), send.ToString()));
            log?.Log(recv);
            int code = recv.Value<int>("code");
            return code == 200;
        }
    }
}
