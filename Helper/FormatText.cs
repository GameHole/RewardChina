using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormatText : MonoBehaviour
{
    string format;
    Text txt;
    public string text { get => !txt ? "" : txt.text; }
    public void SetValues(params string[] values)
    {
        if (format == null)
        {
            txt = GetComponent<Text>();
            format = txt.text;
        }
        txt.text = string.Format(format, values);
    }
}
