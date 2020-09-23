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
        public void Show()
        {
            dia.Open(100);
            btn.ShowBtnType(1);
            text.SetValues("50");
            dia.onCloseBtnClick = () =>
            {
                data.money += 100;
            };
            btn.onClick = () =>
            {
                data.money += 100 * 50;
                onReward?.Invoke();
                dia.onCloseBtnClick = null;
                dia.Close();
            };
        }
    }
}

