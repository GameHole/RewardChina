using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RewardChina
{
    interface IRewardDialog : IInterface
    {
        void Open(int money);
        void Close();
        event Action onClose;
        Action onCloseBtnClick { get; set; }
    }
}

