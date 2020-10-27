using System.Collections.Generic;
using UnityEngine;
namespace Reward.China
{
    public class MsgLog : IMsgLog
    {
        public bool debug { get; set; }

        public void Log(object msg)
        {
            if (debug)
                Debug.Log(msg);
        }
    }
}
