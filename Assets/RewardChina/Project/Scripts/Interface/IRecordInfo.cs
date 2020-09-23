using System.Collections.Generic;
using System.Threading.Tasks;

namespace RewardChina
{
    public interface IRecordInfo : IInterface
    {
        Task<List<RecordInfo>> GetInfos(int id);
    }
}

