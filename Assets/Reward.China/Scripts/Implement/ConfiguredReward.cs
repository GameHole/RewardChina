using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RewardChina
{
    public class ConfiguredReward : MonoBehaviour,IConfiguredReward
    {
        public Action onReward { get; set; }
        public FormatText text;
        IRewardDialog dia;
        IRewardBtn btn;
        IUserData data;
        IRemoteApi remote;
        public async void Show()
        {
            var info = await remote.GetGold(2);
            if (!info.isShow) return;
            dia.onCloseBtnClick = async() =>
            {
                await remote.SetGold(info.money); 
                data.money += info.money;
            };
            dia.Open(info.money);
            btn.ShowBtnType(2);
            text.SetValues(info.other.ToString());
            btn.onClick = async() =>
            {
                await remote.SetGold(info.other);
                data.money += info.other;
                dia.onCloseBtnClick = null;
                dia.Close();
                onReward?.Invoke();
            };
        }
    }
}

