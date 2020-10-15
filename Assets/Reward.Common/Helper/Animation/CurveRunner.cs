using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveRunner : MonoBehaviour
{
    public AnimationCurve curve;
    public float increase;
    public float speed = 1;
    public float output;
    void Update()
    {
        increase += Time.deltaTime * speed;
        if (increase < 0)
            increase = 0;
        else if (increase > 1)
            increase = 1;
        output = curve.Evaluate(increase);
    }
}
