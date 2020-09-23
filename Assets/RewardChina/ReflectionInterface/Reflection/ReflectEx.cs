using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
namespace Refinter
{
    public static class ReflectEx
    {
        static Assembly _workAssembly;
        public static Assembly workAssembly
        {
            get
            {
                if (_workAssembly == null)
                    LoadCSharp();
                return _workAssembly;
            }
        }
        public static void Inject(object obj, object inter)
        {
            if (inter == null) return;
            var itrType = inter.GetType();
            foreach (var item in obj.GetType().GetFields(BindingFlags.Instance| BindingFlags.Public| BindingFlags.NonPublic))
            {
                if (item.FieldType.IsAssignableFrom(itrType))
                {
                    item.SetValue(obj, inter);
                }
            }

        }
        public static T Instance<T>()
        {
            var find = FindImpl(typeof(T));
            if (find != null)
                return (T)Activator.CreateInstance(find);
            return default;
        }
        public static object Instance(Type type)
        {
            var find = FindImpl(type);
            if (find != null)
            {
                if (find.IsSubclassOf(typeof(MonoBehaviour)))
                    return FindIMonoImpl(find);
                return Activator.CreateInstance(find);
            }
            return null;
        }
        public static object FindIMonoImpl(Type type)
        {
            var f = Resources.FindObjectsOfTypeAll(type);
            if (f.Length > 0)
                return f[0];
            return null;
        }
        public static Type FindImpl(Type inter)
        {
            foreach (var item in workAssembly.GetTypes())
            {
                if (isIgnore(item)) continue;
                if (inter.IsAssignableFrom(item))
                    return item;
            }
            return null;
        }
        static void LoadCSharp()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.GetName().Name == "Assembly-CSharp")
                {
                    _workAssembly = assembly;
                    return;
                }
            }
        }
        static bool isIgnore(Type type)
        {
            return type.IsInterface || type.IsAbstract || type.IsGenericType;
        }
    }
}
