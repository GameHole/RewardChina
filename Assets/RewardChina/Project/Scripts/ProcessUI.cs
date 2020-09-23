using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RewardChina
{
    public class ProcessUI : MonoBehaviour
    {
        public Image fg;
        public Text text;
        float _process;
        public float process
        {
            get => _process;
            set
            {
                _process = value;
                if (_process > 1)
                    _process = 1;
                fg.fillAmount = _process;
                text.text = $"{(_process * 100).ToString("f2")}%";
            }
        }
    }
}

