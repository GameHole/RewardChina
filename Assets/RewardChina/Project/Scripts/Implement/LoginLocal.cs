using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace RewardChina
{
    public class LoginLocal : ILogin
    {
        IUserData user;
        public Task Login(string url, string data)
        {
            user.money = 5000;
            return Task.CompletedTask;
        }
    }
    public class UserData : IUserData
    {
        public int money { get; set; }
    }
}

