using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected Rigidbody Rigidbody;
    [SerializeField] private Collision _collision;
    [SerializeField] protected Player Player;

    public void Initialize(int force, Player player)
    {
        _collision.Initialize(force);
        Player = player;
    }

    public void Launch(Vector3 force)
    {
        Rigidbody.AddForce(force, ForceMode.Impulse);
    }
}
