using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Reward.China
{
    public class RecordPage : MonoBehaviour
    {
        IRecordInfo info;
        IMoneyForUI forUI;
        public int id;
        public Transform parent;
        public RecordItem item;
        public GameObject noMsg;
        List<RecordItem> items = new List<RecordItem>();
        public async void Show(bool a)
        {
            gameObject.SetActive(a);
            if (a)
            {
                showInternal(await info.GetInfos(id));
            }
        }
        void showInternal(List<RecordInfo> infos)
        {
            int last = infos.Count - items.Count;
            for (int i = 0; i < last; i++)
            {
                var clone = Instantiate(item, parent);
                clone.transform.localScale = Vector3.one;
                items.Add(clone);
            }
            int s = 0;
            for (; s < infos.Count; s++)
            {
                items[s].gameObject.SetActive(true);
                items[s].moneyTxt.SetValues(forUI.ToString(infos[s].money));
                items[s].timeTxt.SetValues(infos[s].time.ToString());
            }
            for (; s < items.Count; s++)
            {
                items[s].gameObject.SetActive(false);
            }
            noMsg.SetActive(infos.Count == 0);
        }
    }
}

