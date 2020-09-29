using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace RewardChina
{
    public class LoginLocal : ILogin
    {
        IUserData user;
        INetInfo info;
        IUrlApi api;
        IHttp http;
        TaskCompletionSource<bool> tcs;
        public Task<bool> Login()
        {
            if (tcs == null)
                tcs = new TaskCompletionSource<bool>();
            WX.onRecvMsg += onRecv;
            WX.Login();
            return tcs.Task;
        }
        async void onRecv(Dictionary<string, string> dic)
        {
            if (int.Parse(dic["type"]) == 0 && int.Parse(dic["errcode"]) == 0)
            {
                JObject json = new JObject();
                json.Add("code", dic["code"]);
                json.Add("version", Application.version);
                json.Add("game", Application.identifier);
                var jo = JsonConvert.DeserializeObject<JObject>(await http.PostStr(api.getApi("login"), json.ToString()));
                int code = jo.Value<int>("code");
                if (code == 200)
                {
                    info.openid = jo["data"]["token"].Value<string>("openid");
                }
                tcs.SetResult(code == 200);
            }
            WX.onRecvMsg -= onRecv;
        }
    }
   
    public class UserData : IUserData
    {
        public int money { get; set; }
    }
    public class NetInfo : INetInfo
    {
        public string openid { get; set; }
    }
}

