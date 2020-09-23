using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace RewardChina
{
    class AdRewardUI : MonoBehaviour, ILookAdReward
    {
        public Action onReward { get; set; }
        IUserData data;
        IRewardDialog dialog;
        IRewardBtn rewardBtn;
        public void Show()
        {
            dialog.Open(100);
            rewardBtn.ShowBtnType(0);
            rewardBtn.onClick = () =>
            {
                data.money += 100;
                Debug.Log("aa");
                dialog.Close();
                onReward?.Invoke();
            };
        }
    }
}

