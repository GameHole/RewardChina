﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Reward.China
{
    public struct AccountInfo
    {
        public bool isSuccess;
        public int lastMoney;
        public int withdrawedMoney;
    }
    public interface IWithdrawApi : IInterface
    {
        Task<AccountInfo> Withdraw(int expectMoney);
    }
}

