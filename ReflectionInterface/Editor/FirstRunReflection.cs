using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Common.Reflection
{
    
    public class FirstRunReflection
    {
        [InitializeOnLoadMethod]
        static void Init()
        {

            SetOrder("e598f802cca8a3f4eb19c7e7b7720d3e", -200);
        }
        static void SetOrder(string guid, int order)
        {
            var mono = AssetDatabase.LoadAssetAtPath<MonoScript>(AssetDatabase.GUIDToAssetPath(guid));
            if (MonoImporter.GetExecutionOrder(mono) != order)
                MonoImporter.SetExecutionOrder(mono, order);
        }
    }
}
