using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Reward.China
{
    public class RemoteRecordInfo : IRecordInfo
    {
        IHttp http;
        IUrlApi url;
        IMoneyForUI forUI;
        INetInfo net;
        IToast toast;
        public async Task<List<RecordInfo>> GetInfos(int id)
        {
            JObject send = new JObject();
            send.Add("game", net.package);
            send.Add("openId", net.openid);
            var recv = JsonConvert.DeserializeObject<JObject>(await http.PostStr(url.getApi("recordinfo"), JsonConvert.SerializeObject(send)));
            UnityEngine.Debug.Log(recv);
            int code = recv.Value<int>("code");
            List<RecordInfo> res = new List<RecordInfo>();
            if (code == 200)
            {
                JArray array = recv["data"] as JArray;
                for (int i = 0; i < array.Count; i++)
                {
                    var item = array[i];
                    if (item.Value<int>("status") == id)
                    {
                        RecordInfo info = new RecordInfo();
                        info.money = item.Value<int>("amount");
                        info.time = GetLocalTime(item.Value<long>("createTime"));
                        res.Add(info);
                    }
                }
            }
            else
            {
                toast?.Show(recv.Value<string>("message"));
            }
            return res;
        }
        public DateTime GetLocalTime(long v)
        {
            return new DateTime(621355968000000000 + v * 10000).ToLocalTime();
        }
    }
}
