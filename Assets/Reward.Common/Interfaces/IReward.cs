using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IReward :IInterface
{
    Action onReward { set; }
    void Show();
}
