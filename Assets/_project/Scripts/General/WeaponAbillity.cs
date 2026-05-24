using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class WeaponAbillity : IAbilityWeapon
{
    private Weapon _weaponPrefab;
    private float _throwForce;
    private int _statsDamage;

    [Inject] private Player _player;

    public WeaponAbillity(Weapon weaponPrefab, float force, int statsDamage)
    {
        _weaponPrefab = weaponPrefab;
        _throwForce = force;
        _statsDamage = statsDamage;
    }

    public WeaponAbillity(Weapon weaponPrefab, float force)
    {
        _weaponPrefab = weaponPrefab;
        _throwForce = force;
    }

    public void Throw(Transform spawnPoint)
    {
        Transform spawnPosition = spawnPoint;
        Quaternion lookRotation = Quaternion.LookRotation(spawnPoint.transform.forward);

        Weapon weapon = Object.Instantiate(_weaponPrefab, spawnPosition.transform.position, lookRotation);
        weapon.Launch(spawnPoint.transform.forward * _throwForce);
        weapon.Initialize(_statsDamage);
    }
}