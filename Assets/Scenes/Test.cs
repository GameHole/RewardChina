using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RewardChina;
public class Test : MonoBehaviour
{
    ILogin login;
    IUserData data;
    // Start is called before the first frame update
    async void Start()
    {
        await login.Login("","");
        Debug.Log(data.money);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
