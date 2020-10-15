using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CurveRunner))]
public class ScaleTo : MonoBehaviour
{
    public Vector3 start;
    public Vector3 dir;
    public bool useCurrent;
    CurveRunner runner;
    private void Awake()
    {
        runner = GetComponent<CurveRunner>();
        if (useCurrent)
        {
            start = transform.localScale;
        }
    }
    void Update()
    {
        Vector3 outPut = start + runner.output * dir;
        transform.localScale = outPut;
    }
}
