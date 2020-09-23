using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TestMsg : MonoBehaviour
{
    IMsgDialog msg;
    IToast toast;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            toast.Show("aaaaa");
            //SceneManager.LoadScene(1);
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
