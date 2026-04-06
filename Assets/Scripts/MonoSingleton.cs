using UnityEngine;

public abstract class MonoSingleton<TSelf> : MonoBehaviour
                where TSelf : MonoSingleton<TSelf>
{
    private static TSelf _instance;
    private static bool _isQuitting;

    public static TSelf Instance
    {
        get
        {
            if (_isQuitting)
                return null;

            if (_instance == null)
            {
                _instance = FindFirstObjectByType<TSelf>(FindObjectsInactive.Include);

                if (_instance == null)
                {
                    Debug.LogError(
                        $"No instance of {typeof(TSelf).Name} found in the scene. " +
                        $"You must place one manually in the scene.");
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
            _instance = (TSelf)this;

        if (_instance == this)
            return;

        Debug.LogWarning(
            $"Duplicate {typeof(TSelf).Name} detected in scene. Destroying duplicate.",
            gameObject);

        Destroy(gameObject);
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
            _instance = null;
    }

    protected virtual void OnApplicationQuit()
    {
        _isQuitting = true;
    }
}