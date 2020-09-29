using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RewardChina
{
    public class UrlApi : MonoBehaviour,IUrlApi
    {
        string basicUrl = "http://47.114.54.66:29031/smAPI/sm/";
        Dictionary<string, string> usls = new Dictionary<string, string>();
        public string getApi(string key)
        {
            tryInit();
            return basicUrl + usls[key];
        }
        public bool debug;
        bool isInited;
        void tryInit()
        {
            if (isInited) return;
            isInited = true;
            if (debug)
            {
                usls.Add("login", "login?access_token=b8b0fad7-74e0-4414-b974-bf2036fdcf13");
            }
            else
            {

            }
        }
    }
}

