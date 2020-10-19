using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Reward.China
{
    public interface ILogin : IInterface
    {
        Task<bool> Login();
    }
    interface INetInfo : IInterface
    {
        string openid { get; set; }
        string version { get; set; }
        string package { get; set; }
        //string GetJson();
    }
}

