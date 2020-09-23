using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace RewardChina
{
    public interface ILogin : IInterface
    {
        Task Login(string url,string data);
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

