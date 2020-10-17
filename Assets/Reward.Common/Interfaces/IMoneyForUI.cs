using System.Collections.Generic;
using UnityEngine;
public interface IMoneyForUI : IInterface
{
    int conversionRatio { get; set; }
    string ToString(int money);
    float ToFloat(int money);
    int ToMoney(float money);
}
