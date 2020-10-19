using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Reward.China
{
    public class MoneyForUI : IMoneyForUI
    {
        public int conversionRatio { get; set; } = 10000;

        public float ToFloat(int money)
        {
            return (float)money /conversionRatio;
        }

        public int ToMoney(float money)
        {
            return (int)(money * conversionRatio);
        }

        public string ToString(int money)
        {
            return ToFloat(money).ToString("f2");
        }
    }
}
