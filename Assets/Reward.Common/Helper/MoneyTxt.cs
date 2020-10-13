using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Reward.Common
{
    public class MoneyTxt : MonoBehaviour
    {
        IUserData user;
        IMoneyForUI forUI;
        FormatText text;
        void Start()
        {
            text = GetComponent<FormatText>();
        }
        void Update()
        {
            text.SetValues(user.money.ToString(), forUI.ToString(user.money));
        }
    }
}

