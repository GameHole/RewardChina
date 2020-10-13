using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
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
