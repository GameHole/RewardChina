using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace RewardChina
{
    public struct RemoteMoneyInfo
    {
        public bool isShow;
        public int money;
        public int other;
    }
    public class RemoveAPI : IRemoteApi
    {
        INetInfo info;
        IHttp http;
        IUrlApi url;
        int type;
        string[] typeStr = new string[]
        {
            "normalPay","multiPay","morePay"
        };
        public async Task<RemoteMoneyInfo> GetGold(int type)
        {
            this.type = type;
            JObject jo = new JObject();
            jo.Add("openId", info.openid);
            jo.Add("game", Application.identifier);
            JObject retJo = JsonConvert.DeserializeObject<JObject>(await http.PostStr(url.getApi("reward"), JsonConvert.SerializeObject(jo)));
            Debug.Log(retJo);
            var ret = new RemoteMoneyInfo();
            int code = retJo.Value<int>("code");
            ret.isShow = code == 200;
            if (ret.isShow)
            {
                var dataJo = retJo["data"];
                ret.money = dataJo.Value<int>("normalPay");
                switch (type)
                {
                    case 2:
                        ret.other=dataJo.Value<int>("morePay");
                        break;
                    case 1:
                        ret.other = dataJo.Value<int>("multiPay");
                        break;
                }
            }
            return ret;
        }
        //RemoteMoneyInfo[] types = new RemoteMoneyInfo[]
        //{
        //    new RemoteMoneyInfo{ money=100, other=1},
        //    new RemoteMoneyInfo{ money=50, other=20},
        //    new RemoteMoneyInfo{ money=100, other=500}
        //};
        //RemoteMoneyInfo TestGold(int type)
        //{
        //    return types[type];
        //}
        public async Task<int> SetGold(int Gold)
        {
            JObject jo = new JObject();
            jo.Add("openId", info.openid);
            jo.Add("game", Application.identifier);
            jo.Add("type", typeStr[type]);
            jo.Add("coin", Gold);
            JObject retJo = JsonConvert.DeserializeObject<JObject>(await http.PostStr(url.getApi("setgold"), JsonConvert.SerializeObject(jo)));
            Debug.Log(retJo);
            return retJo.Value<int>("code") - 200;
        }
    }
}

