using UnityEngine;

namespace Project.Template
{
#if UNITY_EDITOR
    public class SingletonComponent<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance
        {
            get
            {
                if (instance == null)
                    throw new System.Exception($"[SingletonComponent] {typeof(T).Name} 타입의 싱글톤 오브젝트가 존재하지 않습니다.");

                return instance;
            }
        }

        #region PRIVATE
        private static T instance;

        protected void Awake()
        {
            if (instance != null)
            {
                Debug.LogError($"[SingletoneComponent] {typeof(T).Name} 타입의 싱글톤 오브젝트가 이미 존재합니다.");
                return;
            }

            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        #endregion
    }
#endif
}