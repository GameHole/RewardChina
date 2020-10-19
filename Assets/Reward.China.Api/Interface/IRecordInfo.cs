using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reward.China
{
    public struct RecordInfo
    {
        public int money;
        public DateTime time;
    }
    public interface IRecordInfo : IInterface
    {
        Task<List<RecordInfo>> GetInfos(int id);
    }
}

