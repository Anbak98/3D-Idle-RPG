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
                    throw new System.Exception($"[SingletonComponent] {typeof(T).Name} Ÿ���� �̱��� ������Ʈ�� �������� �ʽ��ϴ�.");

                return instance;
            }
        }

        #region PRIVATE
        private static T instance;

        protected void Awake()
        {
            if (instance != null)
            {
                Debug.LogError($"[SingletoneComponent] {typeof(T).Name} Ÿ���� �̱��� ������Ʈ�� �̹� �����մϴ�.");
                return;
            }

            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        #endregion
    }
#endif
}