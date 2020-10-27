using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Reward.China
{
    public class HeadUI : MonoBehaviour
    {
        IHeadInfo info;
        public Image head;
        public Sprite defHead;
        public Text nickTxt;
        private void Update()
        {
            if(info.tryGetHeadImg(out Sprite headSp))
            {
                head.sprite = headSp;
            }
            else
            {
                head.sprite = defHead;
            }
            if (nickTxt)
                nickTxt.text = info.nick;
            //Debug.Log($"nick::{info.nick}");
        }
    }
}

