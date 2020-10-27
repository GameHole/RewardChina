using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Reward.China
{
    public class RemoveAPI : IRemoteApi
    {
        INetInfo info;
        IHttp http;
        IUrlApi url;
        IUserData data;
        IMsgLog log;
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
            jo.Add("game", info.package);
            JObject retJo = JsonConvert.DeserializeObject<JObject>(await http.PostStr(url.getApi("reward"), JsonConvert.SerializeObject(jo)));
            log?.Log(retJo);
            var ret = new RemoteMoneyInfo();
            int code = retJo.Value<int>("code");
            ret.isShow = code == 200;
            if (ret.isShow)
            {
                var dataJo = retJo["data"];
                ret.money = dataJo.Value<int>("normalPay");
                ret.other = dataJo.Value<int>("multiPay") / ret.money;
                switch (type)
                {
                    case 2:
                        ret.other=dataJo.Value<int>("morePay");
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
        public async Task<int> SetGold(int Gold,int extraType)
        {
            JObject jo = new JObject();
            jo.Add("openId", info.openid);
            jo.Add("game", info.package);
            jo.Add("type", typeStr[extraType < 0 ? type : extraType]);
            jo.Add("coin", Gold);
            log?.Log(jo);
            JObject retJo = JsonConvert.DeserializeObject<JObject>(await http.PostStr(url.getApi("setgold"), JsonConvert.SerializeObject(jo)));
            log?.Log(retJo);
            int code = retJo.Value<int>("code") - 200;
            if (code == 0)
                data.money = retJo["data"].Value<int>("total");
            return code;
        }
    }
}

