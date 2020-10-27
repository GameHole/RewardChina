﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace Reward.China
{
    public class WithdrawApi : IWithdrawApi
    {
        IHttp http;
        IUrlApi url;
        INetInfo info;
        IUserData data;
        IMsgLog log;
        public async Task<AccountInfo> Withdraw(int expectMoney)
        {
            JObject jo = new JObject();
            jo.Add("openId", info.openid);
            jo.Add("game", info.package);
            jo.Add("amount", expectMoney);
            jo.Add("configId", 0);
            log?.Log(jo);
            var resJo = JsonConvert.DeserializeObject<JObject>(await http.PostStr(url.getApi("withdraw"), jo.ToString()));
            log?.Log(resJo);
            var accInfo = new AccountInfo();
            accInfo.isSuccess = resJo.Value<int>("code") == 200;
            if (accInfo.isSuccess)
            {
                data.money = accInfo.lastMoney = resJo["data"].Value<int>("total");
                accInfo.withdrawedMoney = resJo["data"].Value<int>("coin");
            }
            return accInfo;
        }
    }
}

