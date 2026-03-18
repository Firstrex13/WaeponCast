using System;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private Rigidbody _rigidbody;

    public event Action<Knife> Destroyed;

    private void OnEnable()
    {
        _collisionDetector.Collided += SendDestroyMessage;
    }

    private void OnDisable()
    {
        _collisionDetector.Collided -= SendDestroyMessage;
    }

    private void Update()
    {
        _rigidbody.position += transform.forward * _speed * Time.deltaTime;
    }
    public void Initialize(Vector3 startPoint, Vector3 direction)
    {
        transform.position = startPoint;
        transform.forward = direction;
    }

    private void SendDestroyMessage()
    {
        Destroyed?.Invoke(this);
    }
}
