using UnityEngine;

public class AbillityUser : MonoBehaviour
{
    [SerializeField] protected Transform SpawnPosition;

    protected float _attackRate;

    protected IAbilityWeapon Weapon;

    public float AttackRate => _attackRate;

    public void SetupAbility(IAbilityWeapon abilityWeapon, float rate)
    {
        Weapon = abilityWeapon;
        _attackRate = rate;
    }

    public virtual void SetupAbility(IAbilityWeapon abilityWeapon, float rate, float manaCost)
    {
        Weapon = abilityWeapon;
        _attackRate = rate;
    }
}
