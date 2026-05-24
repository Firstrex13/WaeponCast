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
        AbillityUser.SetupAbility(new WeaponAbillity(_lightningConfig.Weapon, _lightningConfig.ThrowForce, Progress.Stats.Force), _lightningConfig.AttackRate, _lightningConfig.ManaCost);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AbillityUser.SetupAbility(new WeaponAbillity(_lightningConfig.Weapon, _lightningConfig.ThrowForce, Progress.Stats.Force), _lightningConfig.AttackRate, _lightningConfig.ManaCost);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AbillityUser.SetupAbility(new WeaponAbillity(_NovaSmallConfig.Weapon, _NovaSmallConfig.ThrowForce, Progress.Stats.Force), _NovaSmallConfig.AttackRate, _NovaSmallConfig.ManaCost);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AbillityUser.SetupAbility(new WeaponAbillity(_fireballConfig.Weapon, _fireballConfig.ThrowForce, Progress.Stats.Force), _fireballConfig.AttackRate, _fireballConfig.ManaCost);
        }
    }

    [Inject]
    public void Construct(IProgressService progress)
    {
        Progress = progress.GetProgress();
    }
}
