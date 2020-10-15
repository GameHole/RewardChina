using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCount : MonoBehaviour
{
    public float time;
    public float add;
    public bool isRun;
    public Action action;
    void Update()
    {
        if (isRun)
        {
            add += Time.deltaTime;
            if (add >= time)
            {
                action?.Invoke();
                isRun = false;
            }
        }
    }
}
