using System.Collections.Generic;
using UnityEngine;
public static class UIEx
{
    public static void MakesureCapcity<T>(this List<T> items,T prefab,Transform layout, int length) where T : MonoBehaviour
    {
        int n = length - items.Count;
        for (int i = 0; i < n; i++)
        {
            var clone = prefab.Instantiate(layout);
            clone.transform.localScale = Vector3.one;
            items.Add(clone);
        }
        for (int i = 0; i < items.Count; i++)
        {
            items[i].gameObject.SetActive(i < length);
        }
    }
}
