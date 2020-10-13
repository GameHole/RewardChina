using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Refinter
{
    public class RefinterMenu 
    {
        [MenuItem("Refinter/Create Initializer")]
        static void Init()
        {
            GameObject go = new GameObject("RefinteInitializer");
            go.AddComponent<Reflection>();
        }
    }
}

