﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Reward.China
{
    public class LoginLocal : ILogin
    {
        IHeadInfo head;
        IUserData user;
        INetInfo info;
        IUrlApi api;
        IHttp http;
        IMsgLog log;
        IMoneyList list;
        TaskCompletionSource<bool> tcs;
        public Task<bool> Login()
        {
            if (tcs == null || tcs.Task.IsCompleted)
                tcs = new TaskCompletionSource<bool>();
            WX.onRecvMsg += onRecv;
            WX.Login();
            return tcs.Task;
        }
        async void onRecv(Dictionary<string, string> dic)
        {
            WX.onRecvMsg -= onRecv;
            try
            {
                if (int.Parse(dic["type"]) == 0 && int.Parse(dic["errcode"]) == 0)
                {
                    JObject json = new JObject();
                    json.Add("code", dic["code"]);
                    json.Add("version", info.version);
                    json.Add("game", info.package);
                    json.Add("device", UniqueId.GetUniteId());
                    log?.Log(json);
                    var jo = JsonConvert.DeserializeObject<JObject>(await http.PostStr(api.getApi("login"), json.ToString()));
                    log?.Log(jo);
                    int code = jo.Value<int>("code");
                    if (code == 200)
                    {
                        info.openid = jo["data"]["token"].Value<string>("openid");
                        head.nick = jo["data"]["token"].Value<string>("nickname");
                        head.headUrl = jo["data"]["token"].Value<string>("avatar");
                        GetGold();
                        list.Init();
                        //UpdateInfo();
                    }
                    tcs.SetResult(code == 200);
                }
            }
            catch (System.Exception e)
            {
                log?.Log(e);
                throw;
            }
            
        }
        public async Task GetGold()
        {
            JObject json = new JObject();
            if (!string.IsNullOrEmpty(info.openid))
                json.Add("openId", info.openid);
            json.Add("game", info.package);
            json.Add("device", info.deviceId);
            log?.Log(json);
            var jo = JsonConvert.DeserializeObject<JObject>(await http.PostStr(api.getApi("getgold"), json.ToString()));
            log?.Log(jo);
            if (jo.Value<int>("code") == 200)
            {
                user.money = jo["data"].Value<int>("amount");
            }
        }
        async void UpdateInfo()
        {
            JObject json = new JObject();
            json.Add("openID", info.openid);
            json.Add("nickname", head.nick);
            json.Add("gameType", info.package);
            json.Add("device", info.deviceId);
            var jo = JsonConvert.DeserializeObject<JObject>(await http.PostStr(api.getApi("update"), json.ToString()));
            log?.Log(jo);
        }
    }
   
   
    public class NetInfo : INetInfo
    {
        public string openid { get; set; }
        public string version { get; set; } = Application.version;
        public string package { get; set; } = Application.identifier;

        public string deviceId { get; set; } = UniqueId.GetUniteId();
    }
}

