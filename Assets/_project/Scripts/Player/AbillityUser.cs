using UnityEngine;

public class AbillityUser : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;

    private IAbilityWeapon _weapon;

    public void ThrowWeapon()
    {
        _weapon.Throw(_spawnPosition);
    }

    public void SetupAbillity(IAbilityWeapon abilityWeapon)
    {
        _weapon = abilityWeapon;
    }
}
