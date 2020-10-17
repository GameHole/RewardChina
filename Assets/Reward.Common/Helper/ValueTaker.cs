using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ValueTaker<T>
{
    public List<float> rates = new List<float>();
    public List<T> values = new List<T>();
    public float totalRate;
    public int RandomTake(out T value)
    {
        if (totalRate == 0)
        {
            for (int i = 0; i < rates.Count; i++)
            {
                totalRate += rates[i];
            }
        }
        int idx = -1;
        value = default;
        float r = Random.Range(0, totalRate);
        for (int i = 0; i < rates.Count; i++)
        {
            r -= rates[i];
            if (r <= 0)
            {
                idx = i;
                break;
            }
        }
        if (idx >= 0)
            value = values[idx];
        return idx;
    }
}
public class RandomTaker
{
    public List<float> rates = new List<float>();
    public float totalRate;
    public int TakeIdx()
    {
        if (totalRate == 0)
        {
            for (int i = 0; i < rates.Count; i++)
            {
                totalRate += rates[i];
            }
        }
        int idx = -1;
        float r = Random.Range(0, totalRate);
        for (int i = 0; i < rates.Count; i++)
        {
            r -= rates[i];
            if (r <= 0)
            {
                idx = i;
                break;
            }
        }
        return idx;
    }
}