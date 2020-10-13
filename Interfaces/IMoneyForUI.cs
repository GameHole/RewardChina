using System.Collections.Generic;
using UnityEngine;
public interface IMoneyForUI : IInterface
{
    string ToString(int money);
    float ToFloat(int money);
}
