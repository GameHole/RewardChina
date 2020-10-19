using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueId 
{
    private static readonly AndroidJavaClass _unique = new AndroidJavaClass("com.unity.uniqueid.UniqueIDTaker");
    public static string GetDeviceId()
    {
        return _unique.CallStatic<string>("getDeviceId", "mark");
    }
    public static string GetAndroidId()
    {
        return _unique.CallStatic<string>("getAndroidId", "mark");
    }
}
