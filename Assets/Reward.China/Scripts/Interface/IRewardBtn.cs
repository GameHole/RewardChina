using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RewardChina
{
    public interface IRewardBtn : IInterface
    {
        Action onClick { set; }
        void ShowBtnType(int id);
    }
}

