using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RewardChina
{
    public class RewardDialog : MonoBehaviour,IRewardDialog
    {
        IMoneyForUI forUI;
        public CountDown down;
        public Button closed;
        public FormatText describ;
        //public FormatText myMoney;
        public FormatText rewardTxt;
        
        private void Start()
        {
            tryInit();
        }
        public void Open(int money)
        {
            tryInit();
            gameObject.SetActive(true);
            closed.gameObject.SetActive(false);
            down.ReStart();
            describ.SetValues(money.ToString(), forUI.ToString(money));
            rewardTxt.SetValues(money.ToString());
        }
        bool isinited;

        public Action onCloseBtnClick { get; set ; }

        public event Action onClose;

        void tryInit()
        {
            if (!isinited)
            {
                isinited = true;
                closed.onClick.AddListener(() =>
                {
                    Close();
                    onCloseBtnClick?.Invoke();
                });
                down.onOver = () =>
                {
                    closed.gameObject.SetActive(true);
                };
            }
        }
        private void Update()
        {
            
        }

        public void Close()
        {
            onClose?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
