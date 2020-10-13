using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IToast : IInterface
{
    void Show(string msg, float durection = 1.5f);
}
