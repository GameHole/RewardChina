using System.Collections;
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
        IMoneyList list;
        public async Task<AccountInfo> Withdraw(int expectMoney)
        {
            if (!list.tryGetId(expectMoney,out int id))
            {
                var accInfo = new AccountInfo();
                accInfo.isSuccess = false;
                accInfo.msg = "请稍后...";
                log?.Log($"not found money config  money = {expectMoney}");
                return accInfo;
            }
            return await WithdrawById(expectMoney, id);
        }

        public async Task<AccountInfo> WithdrawById(int expectMoney,int configedId)
        {
            var accInfo = new AccountInfo();
            JObject jo = new JObject();
            jo.Add("openId", info.openid);
            jo.Add("game", info.package);
            jo.Add("amount", expectMoney);
            jo.Add("configId", configedId);
            log?.Log(jo);
            var resJo = JsonConvert.DeserializeObject<JObject>(await http.PostStr(url.getApi("withdraw"), jo.ToString()));
            log?.Log(resJo);

            accInfo.isSuccess = resJo.Value<int>("code") == 200;
            if (accInfo.isSuccess)
            {
                data.money -= expectMoney;
                //data.money = accInfo.lastMoney = resJo["data"].Value<int>("total");
                //accInfo.withdrawedMoney = resJo["data"].Value<int>("coin");
            }
            else
            {
                accInfo.msg = resJo.Value<string>("message");
            }
            return accInfo;
        }
    }
}

