using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
namespace Reward.China
{
    public class MoneyList : IMoneyList
    {
        IUrlApi api;
        IHttp http;
        INetInfo info;
        IToast toast;
        List<int> moneys = new List<int>();
        public List<int> GetMoneys()
        {
            return moneys;
        }

        public async Task Init()
        {
            var send = new JObject();
            send.Add("game", info.package);
            send.Add("openId", info.openid);
            var recv = JsonConvert.DeserializeObject<JObject>(await http.PostStr(api.getApi("moneylist"), JsonConvert.SerializeObject(send)));
            if (recv.Value<int>("code") == 200)
            {
                JArray array = recv.Value<JArray>("data");
                for (int i = 0; i < array.Count; i++)
                {
                    var item = array[i];
                    moneys.Add(item.Value<int>("amount"));
                }
            }
            else
            {
                toast?.Show(recv.Value<string>("message"));
            }
        }
    }
}
