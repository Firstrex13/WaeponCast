using UnityEngine;

public class AbillityUser : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Mana _mana;

    private float _attackRate;
    private float _manaCost;

    private IAbilityWeapon _weapon;

    public float AttackRate => _attackRate;
    public float ManaCost => _manaCost;

    public void ThrowWeapon()
    {
        _weapon.Throw(_spawnPosition);
        _mana.Reduce(ManaCost);

    }

    public void SetupAbillity(IAbilityWeapon abilityWeapon, float rate, float manaCost)
    {
        _weapon = abilityWeapon;
        _attackRate = rate;
        _manaCost = manaCost;
    }
}
