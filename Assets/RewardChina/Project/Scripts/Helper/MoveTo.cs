using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RewardChina
{
    public class MoveTo : MonoBehaviour
    {
        public AnimationCurve curve;
        public Vector3 start;
        public Vector3 dir;
        public float increase;
        public float speed = 1;
        public bool useLocal;
        public bool useCurrent;
        private void Awake()
        {
            if(useCurrent)
            {
                start = useLocal ? transform.localPosition : transform.position;
            }
        }
        private void Update()
        {
            increase += Time.deltaTime * speed;
            Vector3 outPut = start + curve.Evaluate(increase) * dir;
            if (useLocal)
                transform.localPosition = outPut;
            else
                transform.position = outPut;
        }
    }
}

