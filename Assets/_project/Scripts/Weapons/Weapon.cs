using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    public void Launch(Vector3 force)
    {
        _rigidbody.AddForce(force, ForceMode.Impulse);
    }
}
