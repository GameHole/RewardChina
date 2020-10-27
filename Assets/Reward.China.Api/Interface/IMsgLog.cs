using System.Collections.Generic;
using UnityEngine;
namespace Reward.China
{
	public interface IMsgLog:IInterface
	{
        bool debug { get; set; }
        void Log(object msg);
	}
}
