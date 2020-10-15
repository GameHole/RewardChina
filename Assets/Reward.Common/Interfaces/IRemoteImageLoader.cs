using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public interface IRemoteImageLoader : IInterface
{
    Task<Sprite> LoadImageAsync(string url);
}
