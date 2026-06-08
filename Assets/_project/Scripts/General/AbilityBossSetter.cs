using UnityEngine;
using Zenject;

public class AbilityBossSetter: AbilitySetterGeneral
{
    [SerializeField] private WeaponConfig _projectileConfig;

    [SerializeField] private Player _player;

    private void Start()
    {
        AbillityUser.SetupAbility(new WeaponAbillity(_projectileConfig.Weapon, _projectileConfig.ThrowForce, _player), _projectileConfig.AttackRate);
    }

    public void Initialize(Player player)
    {
        _player = player;
    }
}