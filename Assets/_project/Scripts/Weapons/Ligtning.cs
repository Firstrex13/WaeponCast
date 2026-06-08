using UnityEngine;

public class Ligtning : Weapon
{
    [SerializeField] private GameObject _projectileParticle;
    [SerializeField] private GameObject _muzzleParticle;

    private void Start()
    {
        Instantiate(_muzzleParticle, transform.position, Quaternion.identity, transform);
        Instantiate(_projectileParticle, transform.position, Quaternion.identity, transform);
    }
}
