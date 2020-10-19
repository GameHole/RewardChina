using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Reward.China
{
    class AdRewardUI : MonoBehaviour, ILookAdReward
    {
        public Action onReward { get; set; }
        IUserData data;
        IRewardDialog dialog;
        IRewardBtn rewardBtn;
        IRemoteApi remote;
        public async void Show()
        {
            var info = await remote.GetGold(0);
            Debug.Log($"isShow::{info.isShow}");
            if (!info.isShow) return;
            dialog.Open(info.money);
            rewardBtn.ShowBtnType(0);
            rewardBtn.onClick = async () =>
            {
                dialog.Close();
                onReward?.Invoke();
                await remote.SetGold(info.money);
                    //data.money += info.money;
            };
        }
    }
}

