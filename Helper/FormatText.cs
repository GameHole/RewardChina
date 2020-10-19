using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class FormatText : MonoBehaviour
{
    static readonly string[] empty = new string[0];
    string format;
    Text txt;
    public string text { get => !txt ? "" : txt.text; }
    string[] tempValues = empty;
    StringBuilder builder = new StringBuilder();
    public void SetValues(params string[] values)
    {
        if (format == null)
        {
            txt = GetComponent<Text>();
            format = txt.text;
        }
        txt.text = string.Format(format, values);
    }
    public void SetValues(int idx,string value)
    {
        if (format == null)
        {
            txt = GetComponent<Text>();
            format = txt.text;
        }
        if (tempValues.Length <= idx)
        {
            var strs = new string[idx + 1];
            Array.Copy(tempValues, strs, tempValues.Length);
            tempValues = strs;
        }
        tempValues[idx] = value;
        txt.text = selfFormat();
    }
    string selfFormat()
    {
        builder.Clear();
        builder.Append(format);
        for (int i = 0; i < tempValues.Length; i++)
        {
            builder.Replace("{"+i+"}", tempValues[i]);
        }
        return builder.ToString();
    }
}
