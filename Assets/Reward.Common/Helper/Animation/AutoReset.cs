using System.Collections.Generic;
using UnityEngine;
namespace RewardSong
{
    [RequireComponent(typeof(CurveRunner))]
	public class AutoReset:MonoBehaviour
	{
        CurveRunner runner;
        private void Awake()
        {
            runner = GetComponent<CurveRunner>();
        }
        private void Update()
        {
            if (runner)
            {
                if (runner.speed > 0 && runner.increase >= 1)
                {
                    runner.increase = 0;
                }
                else if (runner.speed < 0 && runner.increase <= 0)
                {
                    runner.increase = 1;
                }
            }
        }
    }
}
