using UnityEngine;

public class WeaponAbillity : IAbilityWeapon
{
    private Weapon _weaponPrefab;
    private float _force;

    public WeaponAbillity(Weapon knifePrefab, float force)
    {
        _weaponPrefab = knifePrefab;
        _force = force;
    }

    public void Throw(Transform spawnPoint)
    {

        Transform spawnPosition = spawnPoint;
        Quaternion lookRotation = Quaternion.LookRotation(spawnPoint.transform.forward);

        Weapon knife = Object.Instantiate(_weaponPrefab, spawnPosition.transform.position, lookRotation);
        knife.Launch(spawnPoint.transform.forward * _force);
    }
}