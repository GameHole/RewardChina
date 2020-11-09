using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Reward.China
{
    public interface ILogin : IInterface
    {
        Task<bool> Login();
        Task GetGold();
    }
    public interface INetInfo : IInterface
    {
        string openid { get; set; }
        string deviceId { get; set; }
        string version { get; set; }
        string package { get; set; }
    }
}

