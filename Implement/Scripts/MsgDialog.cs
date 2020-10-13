using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Refinter;
namespace Reward.Common
{
    public class MsgDialog : MonoBehaviour,IMsgDialog
    {
        public Animator anim;
        public Button close;
        public Text txt;
        Action action;
        private void Start()
        {
            close.onClick.AddListener(() =>
            {
                close.interactable = false;
                anim.SetBool("isShow", false);
                this.Wait(0.5f, () =>
                {
                    gameObject.SetActive(false);
                });
                action?.Invoke();
            });
        }
        public void Show(string msg, Action onClose = null)
        {
            action = onClose;
            txt.text = msg;
            close.interactable = true;
            gameObject.SetActive(true);
            anim.SetBool("isShow", true);
        }
    }
}

