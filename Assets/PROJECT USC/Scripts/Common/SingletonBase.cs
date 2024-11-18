using System;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace USC
{
    public class SingletonBase<T> : MonoBehaviour where T : class
    {
        public static T Singleton
        {
            get
            {
                return instance.Value;
            }
        }

        private static readonly Lazy<T> instance = new Lazy<T>(() =>
        {
            T instance = FindObjectOfType(typeof(T)) as T;

            if (instance == null)
            {
                GameObject obj = new GameObject(typeof(T).ToString());
                instance = obj.AddComponent(typeof(T)) as T;

#if UNITY_EDITOR
                if (EditorApplication.isPlaying)
                {
                    DontDestroyOnLoad(obj);
                }
#else
                DontDestroyOnLoad(obj);
#endif
            }

            return instance;
        });
    }
}
