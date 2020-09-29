using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace RewardChina
{
    public struct RemoteMoneyInfo
    {
        public int money;
        public int other;
    }
    public class RemoveAPI : IRemoteApi
    {
        public Task<RemoteMoneyInfo> GetGold(int type)
        {
            TaskCompletionSource<RemoteMoneyInfo> tcs = new TaskCompletionSource<RemoteMoneyInfo>();
            RemoteMoneyInfo gs = TestGold(type);
            tcs.SetResult(gs);
            return tcs.Task;
        }
        RemoteMoneyInfo[] types = new RemoteMoneyInfo[]
        {
            new RemoteMoneyInfo{ money=100, other=1},
            new RemoteMoneyInfo{ money=50, other=20},
            new RemoteMoneyInfo{ money=100, other=500}
        };
        RemoteMoneyInfo TestGold(int type)
        {
            return types[type];
        }
        public Task<int> SetGold(int Gold)
        {
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            tcs.SetResult(0);
            return tcs.Task;
        }
    }
}

