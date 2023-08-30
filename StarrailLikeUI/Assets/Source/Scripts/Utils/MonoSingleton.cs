using UnityEngine;

public class MonoSingleton<TMonoBehaviour> : MonoBehaviour where TMonoBehaviour : MonoBehaviour
{
    protected static TMonoBehaviour _instance;

    public static TMonoBehaviour Instance
    {
        get { return _instance; }
    }
}
