using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Reward.Common
{
    public class Toast : MonoBehaviour, IToast
    {
        public Text txt;
        public TimeCount time;
        public void Show(string msg, float durection = 1.5F)
        {
            txt.text = msg;
            time.time = durection;
            time.add = 0;
            time.isRun = true;
            gameObject.SetActive(true);
        }
        private void Update()
        {
            gameObject.SetActive(time.isRun);
        }
    }
}

