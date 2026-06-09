using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected Rigidbody Rigidbody;
    [SerializeField] protected Player Player;
    [SerializeField] protected GameObject ProjectileParticle;
    [SerializeField] protected GameObject MuzzleParticle;

    [SerializeField] private Collision _collision;

    private void Start()
    {
        Instantiate(MuzzleParticle, transform.position, Quaternion.identity, transform);
        Instantiate(ProjectileParticle, transform.position, Quaternion.identity, transform);
    }

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
