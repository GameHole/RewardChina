using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RewardChina
{
    public class MoneyItem : MonoBehaviour
    {
        public int id;
        public int dia;
        public Button button;
        public GameObject newUser;
        public GameObject select;
        public FormatText money;
        public FormatText diaTxt;
        public FormatText people;
        public ProcessUI process;
        IUserData data;
        IMoneyForUI forUI;
        private void Update()
        {
            diaTxt.SetValues(dia.ToString());
            float m = forUI.ToFloat(dia);
            money.SetValues(m<1?m.ToString("f2"):m.ToString("f0"));
            process.process = (float)data.money / dia;
        }
    }
}

