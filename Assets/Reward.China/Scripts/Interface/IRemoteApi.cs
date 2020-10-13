using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace RewardChina
{
    public interface IRemoteApi:IInterface
    {
        Task<RemoteMoneyInfo> GetGold(int type);
        Task<int> SetGold(int Gold);
    }
}

