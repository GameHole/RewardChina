using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Refinter
{
    public class Reflection : MonoBehaviour
    {
        internal static readonly Dictionary<Type, IInterface> interfaces = new Dictionary<Type, IInterface>();
        static Dictionary<Type, bool> injected = new Dictionary<Type, bool>();
        static Dictionary<MonoBehaviour, bool> monoInjected = new Dictionary<MonoBehaviour, bool>();
        void Awake()
        {
            InjectSence();
            SceneManager.sceneLoaded += (a,b)=>
            {
                InjectSence();
            };
        }
        void InjectSence()
        {
            foreach (var item in ReflectEx.workAssembly.GetTypes())
            {
                if (item == typeof(IInterface) || interfaces.ContainsKey(item)) continue;
                if (typeof(IInterface).IsAssignableFrom(item) && item.IsInterface)
                {
                    var instence = ReflectEx.Instance(item) as IInterface;
                    if (instence != null)
                        interfaces.Add(item, instence);
                }
            }
            foreach (var obj in interfaces)
            {
                if (injected.ContainsKey(obj.Key)) continue;
                injected.Add(obj.Key, true);
                foreach (var inter in interfaces.Values)
                {
                    ReflectEx.Inject(obj.Value, inter);
                }
            }
            foreach (var obj in Resources.FindObjectsOfTypeAll<MonoBehaviour>())
            {
                if (obj.GetType().FullName.Contains("UnityEngine")) continue;
                if (monoInjected.ContainsKey(obj)) continue;
                monoInjected.Add(obj, true);
                Inject(obj);
                //Debug.Log(obj);
            }
        }
        public static void Inject(MonoBehaviour mono)
        {
            foreach (var item in interfaces.Values)
            {
                ReflectEx.Inject(mono, item);
            }
        }
    }

}
