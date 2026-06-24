using UnityEngine;
using Zenject;

public class AbilityPlayerSetter : AbilitySetterGeneral
{
    [SerializeField] private WeaponConfig _lightningConfig;
    [SerializeField] private WeaponConfig _NovaSmallConfig;
    [SerializeField] private WeaponConfig _fireballConfig;

    public PlayerProgress Progress { get; private set; }

    private void Start()
    {
        SetWeapon();
        Debug.Log($"Weapon {Weapons.CurrentWeapon} chosen");
    }

    public void SetWeapon()
    {
        if(Weapons.CurrentWeapon == WeaponsList.LIGHTNING)
        {
            AbillityUser.SetupAbility(new WeaponAbillity(_lightningConfig.Weapon, _lightningConfig.ThrowForce, Progress.Stats.Force), _lightningConfig.AttackRate - Progress.Stats.AttackRate, _lightningConfig.ManaCost);
        }
        else if(Weapons.CurrentWeapon == WeaponsList.FIREBALL)
        {
            AbillityUser.SetupAbility(new WeaponAbillity(_fireballConfig.Weapon, _fireballConfig.ThrowForce, Progress.Stats.Force), _fireballConfig.AttackRate - Progress.Stats.AttackRate, _fireballConfig.ManaCost);
        }      
    }

    [Inject]
    public void Construct(IProgressService progress)
    {
        Progress = progress.GetProgress();
    }
}
