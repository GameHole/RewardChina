using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace RewardChina
{
    public interface IUrlApi : IInterface
    {
        string getApi(string key);
    }
    public interface ILogin : IInterface
    {
        Task<bool> Login();
    }
    interface INetInfo : IInterface
    {
        string openid { get; set; }
    }
    public interface IUserData:IInterface
    {
        int money { get; set; }
    }
    public interface IMoneyForUI : IInterface
    {
        string ToString(int money);
        float ToFloat(int money);
    }
}

