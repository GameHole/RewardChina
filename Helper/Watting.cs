using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
public static class Waitting
{
    public static Task WaitAsync(float time)
    {
        return Task.Delay((int)(time * 1000));
    }
}
