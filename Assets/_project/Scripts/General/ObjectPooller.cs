using System.Collections.Generic;
using UnityEngine;

public class ObjectPooller : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _capacity;

    private List<GameObject> _pools;

    private void Awake()
    {
        Create();
    }

    private void Create()
    {
        _pools = new List<GameObject>();

        for (int i = 0; i < _capacity; i++)
        {
            CreateNewObject();
        }
    }

    private GameObject CreateNewObject()
    {
        GameObject pooledObject = Instantiate(_prefab, transform.position, transform.rotation, transform);
        pooledObject.gameObject.SetActive(false);
        _pools.Add(pooledObject);
        return pooledObject;
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject pooledObject in _pools)
        {
            if (!pooledObject.gameObject.activeSelf)
            {
                return pooledObject;
            }
        }

        return CreateNewObject();
    }
}
