using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Reward.China
{
	public interface ICounter:IInterface
	{
        Task<int> GetCount(int id, int defaultV = 0);
        Task<bool> Increment(int id);
	}
}
