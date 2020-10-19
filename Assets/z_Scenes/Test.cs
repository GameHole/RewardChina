using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Reward.China;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
                SceneManager.LoadScene(1);
                data.money = 10000;
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
