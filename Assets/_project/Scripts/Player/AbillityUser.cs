using UnityEngine;

public class AbillityUser : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;

    [SerializeField] private float _attackRate; 

    private IAbilityWeapon _weapon;

    public float AttackRate => _attackRate;

    public void ThrowWeapon()
    {
        _weapon.Throw(_spawnPosition);
    }

    public void SetupAbillity(IAbilityWeapon abilityWeapon, float rate)
    {
        _weapon = abilityWeapon;
        _attackRate = rate;
    }
}
