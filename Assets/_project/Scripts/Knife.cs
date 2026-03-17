using System;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 40;

    public event Action<Knife> Destroyed;

    public void Initialize(Vector3 startPoint, Vector3 direction)
    {
        transform.position = startPoint;
        transform.forward = direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(_damageAmount);
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }

        if(other.TryGetComponent<Wall>(out _))
        {
            //Destroyed?.Invoke(this);
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    //public void TurnOn()
    //{
    //    gameObject.SetActive(true);
    //}
}
