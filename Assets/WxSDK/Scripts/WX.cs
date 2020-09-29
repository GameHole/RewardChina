using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

class WxMsgRecever : MonoBehaviour
{
    public void onRecv(string msg)
    {
       
        Debug.Log($"unity on  receve msg -> {msg}");
        string[] datas = msg.Split(',');
        if (datas.Length > 0)
        {
            if (WX.onRecvMsg == null)
            {
                int type = int.Parse(datas[0]);
                int errcode = int.Parse(datas[1]);
                if (type == 0)
                {
                    WX.onLogined?.Invoke(errcode == 0);
                    if (errcode == 0)
                    {
                        string code = datas[2];
                        onLogin(code);
                    }
                }
            }
            else
            {
                Dictionary<string, string> msgDic = new Dictionary<string, string>();
                msgDic.Add("type", datas[0]);
                msgDic.Add("errcode", datas[1]);
                msgDic.Add("code", datas[2]);
                WX.onRecvMsg.Invoke(msgDic);
            }
        }
    }
    async void onLogin(string code)
    {
        try
        {
            string json = await HttpHelper.Get($"https://api.weixin.qq.com/sns/oauth2/access_token?appid={WX.Appid}&secret={WX.appsecret}&code={code}&grant_type=authorization_code");
            Debug.Log(json);
            var jo = JsonConvert.DeserializeObject<JObject>(json);
            if (jo.TryGetValue("access_token", out JToken token))
            {
                onGetInfo(token.Value<string>(), jo.Value<string>("openid"));
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            throw;
        }
    }
    async void onGetInfo(string token, string openId)
    {
        try
        {
            WX.openid = openId;
           
            Debug.Log($"tk:{token},oid::{openId}");
            var json = await HttpHelper.Get($"https://api.weixin.qq.com/sns/userinfo?access_token={token}&openid={openId}");
            Debug.Log(json);
            var jo = JsonConvert.DeserializeObject<JObject>(json);
            if(jo.TryGetValue("openid",out JToken jtk))
            {
                WX.nickName = jo.Value<string>("nickname");
                WX.headurl = jo.Value<string>("headimgurl");
                WX.onGetUserInfo?.Invoke(WX.headurl, WX.nickName);
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            throw;
        }
    }
}
public static class WX 
{
    public static Action<Dictionary<string, string>> onRecvMsg;
    public static Action<bool> onLogined;
    public static Action<string, string> onGetUserInfo;
    public static string openid;
    public static string nickName;
    public static string headurl;
    public static string appsecret;
    public static string Appid;
    private static WxMsgRecever msg;
#if UNITY_ANDROID
    private static AndroidJavaClass sdk;
    class WxProxy : AndroidJavaProxy
    {
        public WxProxy() : base("com.unity.unitywxapi.IWxUnityMsg")
        {
        }
        public void onResp(string msg)
        {
            WX.msg.onRecv(msg);
        }
    }
#elif UNITY_IOS
    [DllImport("__Internal")]
    private extern static void _registerApp(string appid, string url);
    [DllImport("__Internal")]
    private extern static void _wechatLogin(string msg);
    [DllImport("__Internal")]
    private extern static bool _isWechatInstalled();
#endif
    static void initRecv()
    {
        if (msg == null)
        {
            var g = new GameObject();
            g.name = "_WxMsgRecever";
            g.hideFlags = HideFlags.HideInHierarchy;
            UnityEngine.Object.DontDestroyOnLoad(g);
            msg = g.AddComponent<WxMsgRecever>();
        }
    }
    public static void RegisteApp(string appid, string universalLinks)
    {
        initRecv();
        Appid = appid;
#if UNITY_ANDROID
        sdk = new AndroidJavaClass("com.unity.unitywxapi.Wx");
        sdk.CallStatic("Init", "mask", appid);
        sdk.CallStatic("BindHandler", "mask", new WxProxy());
#elif UNITY_IOS
        //Debug.Log("RegisteApp:" + appid);
        _registerApp(appid, universalLinks);
#endif
    }
    public static void Login(string msg="")
    {
#if UNITY_EDITOR
        Dictionary<string, string> msgDic = new Dictionary<string, string>();
        msgDic.Add("type", "0");
        msgDic.Add("errcode", "0");
        msgDic.Add("code", "1");
        onRecvMsg?.Invoke(msgDic);
        onLogined?.Invoke(true);
        onGetUserInfo?.Invoke("", "test");
#elif UNITY_ANDROID
        sdk.CallStatic("Login", "mask");
#elif UNITY_IOS
        _wechatLogin(msg);
#endif
    }
    public static bool isWechatInstalled()
    {
#if UNITY_EDITOR||UNITY_ANDROID
        return true;
#elif UNITY_IOS
        return _isWechatInstalled();
#endif
    }
}
