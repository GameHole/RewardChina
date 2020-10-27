﻿using System.Collections.Generic;
using System.Threading.Tasks;
namespace Reward.China
{
    public interface IMoneyList : IInterface
    {
        Task Init();
        List<int> GetMoneys();
    }
}
