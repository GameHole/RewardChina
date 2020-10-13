using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public interface IHttp:IInterface
{
    Task<string> GetStr(string url);
    Task<byte[]> GetBytes(string url);
    Task<string> PostStr(string url, string data);
    Task<byte[]> PostBytes(string url, string data);
}
