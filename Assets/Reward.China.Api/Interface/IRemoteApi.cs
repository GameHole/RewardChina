using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Reward.China
{
    public struct RemoteMoneyInfo
    {
        public bool isShow;
        public int money;
        public int other;
        public int errcode;
    }
    public interface IRemoteApi:IInterface
    {
        int errcode { get; }
        Task<RemoteMoneyInfo> GetGold(int type, string configName = "default");
        Task<bool> SetGold(int Gold, int extraType = -1);
    }
}

