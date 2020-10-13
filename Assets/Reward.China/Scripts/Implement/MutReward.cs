using System;
using UnityEngine;
using UnityEngine.UI;

namespace RewardChina
{
    class MutReward : MonoBehaviour,IMultipleReward
    {
        public Action onReward { get; set; }
        public FormatText text;
        IRewardDialog dia;
        IRewardBtn btn;
        IUserData data;
        IRemoteApi remote;
        public async void Show()
        {
            var info = await remote.GetGold(1);
            if (!info.isShow) return;
            dia.Open(info.money);
            btn.ShowBtnType(1);
            text.SetValues(info.other.ToString());
            int money = info.money * info.other;
            dia.onCloseBtnClick = async () =>
            {
                await remote.SetGold(info.money);
                data.money += info.money;
            };
            btn.onClick = async() =>
            {
                await remote.SetGold(money);
                data.money += money;
                onReward?.Invoke();
                dia.onCloseBtnClick = null;
                dia.Close();
            };
        }
    }
}

