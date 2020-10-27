using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CurveRunner))]
public class DestroyWhenAnimFinish : MonoBehaviour
{
    CurveRunner runner;
    void Start()
    {
        runner = GetComponent<CurveRunner>();
    }
    void Update()
    {
        if (runner.speed > 0 && runner.increase >= 1 || runner.speed < 0 && runner.increase <= 0)
        {
            Destroy(gameObject);
        }
    }
}
