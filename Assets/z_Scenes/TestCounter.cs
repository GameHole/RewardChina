using System.Collections.Generic;
using UnityEngine;
using Reward.China;
using System;

namespace Default
{
	public class TestCounter:MonoBehaviour
	{
        IRemoteApi remote;
        ICounter counter;
        IMsgLog Log;
        INetInfo info;
        public string did = "TestDeviceId---1";
        public string oid = "oXMto1LOSU0skZmaqLu3bAkQIDZE";
        public int counterID=0;
        private void Awake()
        {
            Log.debug = true;
            Debug.Log(new DateTime(1970, 1, 1).Ticks);
            DateTime date = DateTime.FromFileTimeUtc(1605001019000);
            Debug.Log(date);
        }
        public async void Inc()
        {
            //info.openid = oid;// "oXMto1LOSU0skZmaqLu3bAkQIDZE";
            //info.deviceId = "123456789";
            //var d = await remote.GetGold(0,"2");
            //Debug.Log(d.money);
            //Debug.Log(await remote.SetGold(d.money));
            //var m = await counter.Increment(0);
            //Debug.Log(m);
            //var b = await counter.GetCount(0);
            //Debug.Log(b);
        }
        public async void TestConfigDefaultNoOID()
        {
            //info.openid = "oXMto1LOSU0skZmaqLu3bAkQIDZE";
            info.deviceId = did;// "TestDeviceId---1";
            var d = await remote.GetGold(0);
            Debug.Log(d.money);
            Debug.Log(await remote.SetGold(d.money));
        }
        public async void TestConfigDefault()
        {
            info.openid = oid;// "oXMto1LOSU0skZmaqLu3bAkQIDZE";
            info.deviceId = did;// "TestDeviceId---1";
            var d = await remote.GetGold(0);
            Debug.Log(d.money);
            Debug.Log(await remote.SetGold(d.money));
        }
        public async void TestChaXunNo()
        {
            //info.openid = "oXMto1LOSU0skZmaqLu3bAkQIDZE";
            info.deviceId = did;// "TestDeviceId---1";
            var d = await remote.GetGold(0);
            Debug.Log(d.money);
            Debug.Log(await remote.SetGold(d.money));
        }
        public async void TestChaXun()
        {
            info.openid = oid;// "oXMto1LOSU0skZmaqLu3bAkQIDZE";
            info.deviceId = did;// "TestDeviceId---1";
            var d = await remote.GetGold(0);
            Debug.Log(d.money);
            Debug.Log(await remote.SetGold(d.money));
        }
        public async void TestCountNo()
        {
            //info.openid = "oXMto1LOSU0skZmaqLu3bAkQIDZE";
            info.deviceId = did;// "TestDeviceId---1";
            var m = await counter.Increment(counterID);
            Debug.Log(m);
            var b = await counter.GetCount(counterID);
            Debug.Log(b);
        }
        public async void TestCount()
        {
            info.openid = oid;// "oXMto1LOSU0skZmaqLu3bAkQIDZE";
            info.deviceId = did;// "TestDeviceId---1";
            var m = await counter.Increment(counterID);
            Debug.Log(m);
            var b = await counter.GetCount(counterID);
            Debug.Log(b);
        }
    }
}
