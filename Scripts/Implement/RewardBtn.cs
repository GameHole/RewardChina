using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Reward.China
{
    public class RewardBtn : MonoBehaviour,IRewardBtn
    {
        public Action onClick { set; get; }
        public GameObject[] buttonTypes;
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                onClick?.Invoke();
            });
        }
        public void ShowBtnType(int id)
        {
            for (int i = 0; i < buttonTypes.Length; i++)
            {
                buttonTypes[i].SetActive(i == id);
            }
        }
    }
}

