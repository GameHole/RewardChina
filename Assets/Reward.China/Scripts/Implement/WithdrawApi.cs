using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace RewardChina
{
    public class WithdrawApi : IWithdrawApi
    {
        IHttp http;
        IUrlApi url;
        INetInfo info;
        public async Task<AccountInfo> Withdraw(int expectMoney)
        {
            JObject jo = new JObject();
            jo.Add("openId", info.openid);
            jo.Add("game", Application.identifier);
            jo.Add("withdrawAmount", expectMoney);
            var resJo = JsonConvert.DeserializeObject<JObject>(await http.PostStr(url.getApi("withdraw"), jo.ToString()));
            var accInfo = new AccountInfo();
            accInfo.isSuccess = resJo.Value<int>("code") == 200;
            if (accInfo.isSuccess)
            {
                accInfo.lastMoney = resJo["data"].Value<int>("total");
                accInfo.withdrawedMoney = resJo["data"].Value<int>("coin");
            }
            return accInfo;
        }
    }
}

