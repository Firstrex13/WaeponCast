using UnityEngine;

public class BaseSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    protected ObjectPool<T> Pool;

    protected int ObjectStartCount;

    protected virtual void OnReturnToPool(T obj)
    {
        Pool.ReturnObject(obj);
    }
}
