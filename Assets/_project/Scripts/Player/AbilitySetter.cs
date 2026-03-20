using UnityEngine;

public class AbilitySetter : MonoBehaviour
{
    [SerializeField] private AbillityUser _abillityUser;

    [SerializeField] private WeaponConfig _lightningConfig;
    [SerializeField] private WeaponConfig _NovaSmallConfig;
    [SerializeField] private WeaponConfig _fireballConfig;

    private void Start()
    {
        _abillityUser.SetupAbillity(new WeaponAbillity(_lightningConfig.Weapon, _lightningConfig.ThrowForce), _lightningConfig.AttackRate, _lightningConfig.ManaCost);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _abillityUser.SetupAbillity(new WeaponAbillity(_lightningConfig.Weapon, _lightningConfig.ThrowForce), _lightningConfig.AttackRate, _lightningConfig.ManaCost);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _abillityUser.SetupAbillity(new WeaponAbillity(_NovaSmallConfig.Weapon, _NovaSmallConfig.ThrowForce), _NovaSmallConfig.AttackRate, _NovaSmallConfig.ManaCost);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _abillityUser.SetupAbillity(new WeaponAbillity(_fireballConfig.Weapon, _fireballConfig.ThrowForce), _fireballConfig.AttackRate, _fireballConfig.ManaCost);
        }
    }
}
