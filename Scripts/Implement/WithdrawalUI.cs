using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Refinter;
using UnityEngine.UI;

namespace Reward.China
{
    public class WithdrawalUI : MonoBehaviour, IWithdrawal
    {
        IUserData user;
        IMsgDialog dialog;
        IToast toast;
        IWithdrawApi api;
        public Transform parent;
        public MoneyItem item;
        public Animator anim;
        public Button withdrawalBtn;
        public Button closeBtn;
        int currId;
        List<MoneyItem> items = new List<MoneyItem>();
        public void Open()
        {
            tryInit();
            anim.SetBool("isShow",true);
        }
        private void Start()
        {
            tryInit();
        }
        bool isInited;
        void tryInit()
        {
            if (isInited) return;
            isInited = true;
            for (int i = 0; i < 6; i++)
            {
                var clone = item.Instantiate(parent);
                clone.transform.localScale = Vector3.one;
                items.Add(clone);
                clone.id = i;
                clone.button.onClick.AddListener(() =>
                {
                    currId = clone.id;
                    Select(currId);
                });
                clone.newUser.SetActive(i == 0);
                clone.select.SetActive(false);
                clone.dia = 5000*(i+1);
                clone.people.SetValues("1000");
            }
            closeBtn.onClick.AddListener(Close);
            withdrawalBtn.onClick.AddListener(async() =>
            {
                if(user.money < items[currId].dia)
                {
                    dialog.Show("金币不足，快去赚金币吧~");
                    return;
                }
                var res = await api.Withdraw(items[currId].dia);
                if (res.isSuccess)
                {
                    toast.Show($"恭喜提现{items[currId].money.text}");
                }
            });
        }
        public void Close()
        {
            anim.SetBool("isShow", false);
        }
        void Select(int id)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].select.SetActive(i == id);
            }
        }
    }
}

