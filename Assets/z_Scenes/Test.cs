﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RewardChina;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    ILogin login;
    IUserData data;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(async () =>
        {
            Debug.Log("aaa");
            if (await login.Login())
            {
                Debug.Log(data.money);
            }
            //Debug.Log("aid::" + UniqueId.GetAndroidId());
            //Debug.Log("did::" + UniqueId.GetDeviceId());
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
