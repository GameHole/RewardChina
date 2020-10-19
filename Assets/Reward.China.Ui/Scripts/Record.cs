using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Reward.China
{
    public class Record : MonoBehaviour
    {
        public Animator anim;
        public Button closeBtn;
        public Button[] pageBtns;
        public RecordPage[] pages;
        public Color[] colors;
        public MoveTo mover;
        Graphic[] childs;
        public void Open()
        {
            tryInit();
            anim.SetBool("isShow", true);
            changePage(0);
        }
        bool isInited;
        void tryInit()
        {
            if (isInited) return;
            isInited = true;
            closeBtn.onClick.AddListener(() =>
            {
                anim.SetBool("isShow", false);
            });
            for (int i = 0; i < pages.Length; i++)
            {
                pages[i].id = i;
            }
            for (int i = 0; i < pageBtns.Length; i++)
            {
                int id = i;
                pageBtns[i].onClick.AddListener(() =>
                {
                    changePage(id);
                });
            }
            childs = new Graphic[pageBtns.Length];
            for (int i = 0; i < pageBtns.Length; i++)
            {
                childs[i] = pageBtns[i].GetComponentInChildren<Text>();
            }
        }
        void changePage(int id)
        {
            showPage(id);
            changeBtnColor(id);
            moveMover(id);
        }
        void showPage(int id)
        {
            for (int i = 0; i < pages.Length; i++)
            {
                pages[i].Show(i == id);
            }
        }
        void changeBtnColor(int id)
        {
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i].color = i == id ? colors[0] : colors[1];
            }
        }
        void moveMover(int id)
        {
            mover.start = mover.transform.localPosition;
            mover.dir = pageBtns[id].transform.localPosition - mover.transform.localPosition;
            mover.dir.y = mover.dir.z = 0;
            mover.GetComponent<CurveRunner>().increase = 0;
        }
    }
}

