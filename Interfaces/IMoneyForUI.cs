using System.Collections.Generic;
using UnityEngine;
public interface IMoneyForUI : IInterface
{
    int conversionRatio { get; set; }
    string ToString(int money, int last = 2);
    float ToFloat(int money);
    int ToMoney(float money);
}
