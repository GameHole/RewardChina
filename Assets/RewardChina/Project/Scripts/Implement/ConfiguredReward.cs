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
        public void Show()
        {
            dia.onCloseBtnClick = () =>
            {
                data.money += 100;
            };
            dia.Open(100);
            btn.ShowBtnType(2);
            text.SetValues("500");
            btn.onClick = () =>
            {
                data.money += 500;
                dia.onCloseBtnClick = null;
                dia.Close();
                onReward?.Invoke();
            };
        }
    }
}

