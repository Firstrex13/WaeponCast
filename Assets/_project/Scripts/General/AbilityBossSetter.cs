using UnityEngine;

public class AbilityBossSetter: AbilitySetterGeneral
{
    [SerializeField] private WeaponConfig _projectileConfig;

    private void Start()
    {
        AbillityUser.SetupAbility(new WeaponAbillity(_projectileConfig.Weapon, _projectileConfig.ThrowForce), _projectileConfig.AttackRate);
    }
}