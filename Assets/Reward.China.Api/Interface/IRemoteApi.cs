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
    }
    public interface IRemoteApi:IInterface
    {
        Task<RemoteMoneyInfo> GetGold(int type);
        Task<int> SetGold(int Gold, int extraType = -1);
    }
}

