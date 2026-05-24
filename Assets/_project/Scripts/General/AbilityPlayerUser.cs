using UnityEngine;

public class AbilityPlayerUser : AbillityUser
{
    [SerializeField] private Mana _mana;

    private float _manaCost;

    public float ManaCost => _manaCost;

    public override void ThrowWeapon()
    {
        base.ThrowWeapon();
        _mana.Reduce(_manaCost);
    }

    public override void SetupAbility(IAbilityWeapon abilityWeapon, float rate, float manaCost)
    {
        base.SetupAbility(abilityWeapon, rate, manaCost);
        _manaCost = manaCost;
    }
}
