using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMsgDialog : IInterface
{
    void Show(string msg, Action onClose = null);
}
