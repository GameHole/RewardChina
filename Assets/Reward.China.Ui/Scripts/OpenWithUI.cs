﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Reward.China
{
    public class OpenWithUI : MonoBehaviour
    {
        IWithdrawal withdrawal;
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(withdrawal.Open);
        }
    }
}
