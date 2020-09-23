using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RewardChina
{
    public class MoneyForUI : IMoneyForUI
    {
        public float ToFloat(int money)
        {
            return (float)money / 10000;
        }

        public string ToString(int money)
        {
            return ToFloat(money).ToString("f2");
        }
    }
}
