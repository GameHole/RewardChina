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
        int id;
        string[] typeStr = new string[]
        {
            "normalPay","multiPay","morePay"
        };
        public async Task<RemoteMoneyInfo> GetGold(int type,string configName)
        {
            this.type = type;
            JObject jo = new JObject();
            if (!string.IsNullOrEmpty(info.openid))
                jo.Add("openId", info.openid);
            jo.Add("game", info.package);
            jo.Add("device", info.deviceId);
            jo.Add("configName", configName);
            log?.Log(jo);
            JObject retJo = JsonConvert.DeserializeObject<JObject>(await http.PostStr(url.getApi("reward"), JsonConvert.SerializeObject(jo)));
            log?.Log(retJo);
            var ret = new RemoteMoneyInfo();
            int code = retJo.Value<int>("code");
            ret.errcode = code;
            ret.isShow = code == 200;
            if (ret.isShow)
            {
                var dataJo = retJo["data"];
                id = dataJo.Value<int>("configId");
                ret.money = dataJo.Value<int>("normalPay");
                ret.other = dataJo.Value<int>("multiPay");
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
        public async Task<bool> SetGold(int Gold, int extraType)
        {
            JObject jo = new JObject();
            if (!string.IsNullOrEmpty(info.openid))
                jo.Add("openId", info.openid);
            jo.Add("game", info.package);
            jo.Add("type", typeStr[extraType < 0 ? type : extraType]);
            jo.Add("deviceId", info.deviceId);
            jo.Add("coin", Gold);
            jo.Add("configId", id);
            log?.Log(jo);
            JObject retJo = JsonConvert.DeserializeObject<JObject>(await http.PostStr(url.getApi("setgold"), JsonConvert.SerializeObject(jo)));
            log?.Log(retJo);
            int code = retJo.Value<int>("code");
            if (code == 200)
                data.money = retJo["data"].Value<int>("total");
            return code == 200;
        }
    }
}

