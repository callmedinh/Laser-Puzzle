using UnityEngine;

namespace _Scripts.Utilities
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<T>();
                }

                if (_instance == null)
                {
                    SetupInstance();
                }
                return _instance;
            }
        }

        public virtual void Awake()
        {
            RemoveDuplicate();
        }

        private static void SetupInstance()
        {
            _instance = FindFirstObjectByType<T>();
            if (_instance == null)
            {
                GameObject singletonObject = new GameObject(typeof(T).Name);
                _instance = singletonObject.AddComponent<T>();
                DontDestroyOnLoad(singletonObject);
            }
        }

        private void RemoveDuplicate()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}