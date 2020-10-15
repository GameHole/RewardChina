using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CurveRunner))]
public class MoveTo : MonoBehaviour
{
    //public AnimationCurve curve;
    public Vector3 start;
    public Vector3 dir;
    //public float increase;
    //public float speed = 1;
    public bool useLocal;
    public bool useCurrent;
    CurveRunner runner;
    private void Awake()
    {
        runner = GetComponent<CurveRunner>();
        if (useCurrent)
        {
            start = useLocal ? transform.localPosition : transform.position;
        }
    }
    private void Update()
    {
        //increase += Time.deltaTime * speed;
        Vector3 outPut = start + runner.output * dir;
        if (useLocal)
            transform.localPosition = outPut;
        else
            transform.position = outPut;
    }
}