using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text text;
    public float time = 3;
    public float add;
    public bool isRun;
    public Action onOver;
    public void ReStart()
    {
        isRun = true;
        add = 0;
    }
    void Update()
    {
        if (isRun)
        {
            add += Time.deltaTime;
            if (add >= time)
            {
                isRun = false;
                onOver?.Invoke();
            }
            text.text = ((int)(time - add)+1).ToString();
        }
        else
        {
            text.text = "";
        }
    }
}
