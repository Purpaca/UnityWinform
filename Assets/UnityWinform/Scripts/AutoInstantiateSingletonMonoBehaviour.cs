using UnityEngine;

/// <summary>
/// 在被尝试访问时会自动实例化的单例模式下的MonoBehaviour基类
/// </summary>
public class AutoInstantiateSingletonMonoBehaviour<T> : MonoBehaviour where T : AutoInstantiateSingletonMonoBehaviour<T>
{
    private static T m_instance;

    protected static T instance
    {
        get
        {
            if (m_instance is null)
            {
                GameObject gameObject = new GameObject(typeof(T).Name);
                m_instance = gameObject.AddComponent<T>();
            }

            return m_instance;
        }
    }

    #region Unity Messages
    protected virtual void Awake()
    {
        if (m_instance is not null && !object.ReferenceEquals(m_instance, this))
        {
            Destroy(this);
            return;
        }

        m_instance = (T)this;
    }
    #endregion
}