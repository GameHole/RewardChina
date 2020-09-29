using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHeadInfo : IInterface
{
    string nick { get; set; }
    string headUrl { get; set; }
    bool tryGetHeadImg(out Sprite sprite);
}
