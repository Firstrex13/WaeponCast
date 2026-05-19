using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collision _collision;

    public void Initialize(int force)
    {
        _collision.Initialize(force);
    }

    public void Launch(Vector3 force)
    {
        _rigidbody.AddForce(force, ForceMode.Impulse);
    }
}
