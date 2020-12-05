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
        IMsgLog log;
        List<int> moneys = new List<int>();
        Dictionary<int, int> money2id = new Dictionary<int, int>();
        public List<int> GetMoneys()
        {
            return moneys;
        }
        //bool isInited;
        public async Task Init()
        {
            //if (isInited) return;
            //isInited = true;
            var send = new JObject();
            send.Add("game", info.package);
            send.Add("openId", info.openid);
            var recv = JsonConvert.DeserializeObject<JObject>(await http.PostStr(api.getApi("moneylist"), JsonConvert.SerializeObject(send)));
            log?.Log(recv);
            if (recv.Value<int>("code") == 200)
            {
                JArray array = recv.Value<JArray>("data");
                for (int i = 0; i < array.Count; i++)
                {
                    var item = array[i];
                    int m = item.Value<int>("amount");
                    if (money2id.ContainsKey(m)) continue;
                    moneys.Add(m);
                    money2id.Add(m, item.Value<int>("id"));
                }
            }
            else
            {
                toast?.Show(recv.Value<string>("message"));
            }
        }

        public bool tryGetId(int money, out int id)
        {
            return money2id.TryGetValue(money, out id);
        }
    }
}
