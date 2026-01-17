using UnityEngine;
using UnityEngine.Pool;

public class Pool <T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefabe;
    [SerializeField] private int _poolCapacity = 100;
    [SerializeField] private int _poolMaxSize = 100;

    private ObjectPool<T> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
        createFunc: () => Instantiate(_prefabe),
        actionOnGet: (prefab) => prefab.gameObject.SetActive(true),
        actionOnRelease: (prefab) => prefab.gameObject.SetActive(false),
        actionOnDestroy: (prefab) => Destroy(prefab.gameObject),
        collectionCheck: true,
        defaultCapacity: _poolCapacity,
        maxSize: _poolMaxSize);
    }

    public T Get()
    {
        return _pool.Get();
    }

    public void Release(T @object) 
    {
        _pool.Release(@object);
    }
}
