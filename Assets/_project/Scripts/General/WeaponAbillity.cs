using UnityEngine;

public class WeaponAbillity : IAbilityWeapon
{
    private Weapon _weaponPrefab;
    private float _force;

    public WeaponAbillity(Weapon weaponPrefab, float force)
    {
        _weaponPrefab = weaponPrefab;
        _force = force;
    }

    public void Throw(Transform spawnPoint)
    {
        Transform spawnPosition = spawnPoint;
        Quaternion lookRotation = Quaternion.LookRotation(spawnPoint.transform.forward);

        Weapon weapon = Object.Instantiate(_weaponPrefab, spawnPosition.transform.position, lookRotation);
        weapon.Launch(spawnPoint.transform.forward * _force);
    }
}