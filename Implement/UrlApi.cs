using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Reward.China
{
    public class UrlApi : MonoBehaviour,IUrlApi
    {
        public string basicUrl = "http://47.114.54.66:29131/";
        public string testToken = "b8b0fad7-74e0-4414-b974-bf2036fdcf13";
        public string releaseToken = "b8b0fad7-74e0-4414-b974-bf2036fdcf13";
        string token;
        Dictionary<string, string> usls = new Dictionary<string, string>();
        public string getApi(string key)
        {
            tryInit();
            return basicUrl + usls[key] + "?access_token=" + token;
        }
        public bool debug;
        bool isInited;
        void tryInit()
        {
            if (isInited) return;
            isInited = true;
            if (debug)
            {
                token = testToken;
            }
            else
            {
                token = releaseToken;
            }
            usls.Add("login", "smAPI/sm/login");
            usls.Add("reward", "smAPI/inspire/config");
            usls.Add("setgold", "smAPI/inspire/getcoin");
            usls.Add("getgold", "smAPI/sm/userdetails");
            usls.Add("update", "smAPI/sm/userinfo");
            usls.Add("withdraw", "smAPI/sm/wxpay");
            usls.Add("recordinfo", "smAPI/sm/withdrawhis");
            usls.Add("moneylist", "smAPI/sm/goods");
        }
    }
}

