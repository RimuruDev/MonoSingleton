// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub:   https://github.com/RimuruDev
//
// **************************************************************** //

using UnityEngine;

namespace RimuruDev
{
    [HelpURL("https://github.com/RimuruDev/MonoSingleton")]
    public abstract class MonoSingleton<TComponent> : MonoBehaviour where TComponent : Component
    {
        private static volatile TComponent instance;
        private static readonly object lockObject = new();

        public static bool HasInstance => instance != null;

        public static TComponent TryGetInstance() => HasInstance ? instance : null;

        public static TComponent Instance
        {
            get
            {
                if (instance != null)
                    return instance;

                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = FindObjectOfType<TComponent>();

                        if (instance == null)
                        {
                            var obj = new GameObject
                            {
                                name = $"[ === {typeof(TComponent).Name} === ]"
                            };

                            instance = obj.AddComponent<TComponent>();
                        }
                    }

                    return instance;
                }
            }
        }

        protected virtual void Awake() =>
            InitializeSingleton();

        protected virtual void InitializeSingleton()
        {
            if (!Application.isPlaying)
                return;

            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = this as TComponent;
                    transform.SetParent(null);
                    DontDestroyOnLoad(gameObject);
                }
                else if (instance != this)
                {
                    Debug.LogError($"Another instance of {typeof(TComponent).Name} already exists. Destroying the duplicate.");
                    Destroy(gameObject);
                }
            }
        }
    }
}
