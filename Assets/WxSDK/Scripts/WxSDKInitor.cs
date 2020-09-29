using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WxSDKInitor : MonoBehaviour
{
    public string appid;
    public string appsecret;
#if UNITY_IOS
    public string universalLinks;
#endif
    // Start is called before the first frame update
    void Awake()
    {
        string link = "";
        WX.appsecret = appsecret;
#if UNITY_IOS
        //string appid = "wx7e44f6f0cb921e85";
        link = universalLinks;
#endif
        WX.RegisteApp(appid, link);
    }
}
