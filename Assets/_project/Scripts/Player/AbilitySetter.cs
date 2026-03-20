using UnityEngine;

public class AbilitySetter : MonoBehaviour
{
    [SerializeField] private AbillityUser _abillityUser;

    [SerializeField] private WeaponConfig _knifeConfig;
    [SerializeField] private WeaponConfig _axeConfig;
    [SerializeField] private WeaponConfig _fireballConfig;

    private void Start()
    {
        _abillityUser.SetupAbillity(new WeaponAbillity(_knifeConfig.Weapon, _knifeConfig.ThrowForce), _knifeConfig.AttackRate);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _abillityUser.SetupAbillity(new WeaponAbillity(_knifeConfig.Weapon, _knifeConfig.ThrowForce), _knifeConfig.AttackRate);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _abillityUser.SetupAbillity(new WeaponAbillity(_axeConfig.Weapon, _axeConfig.ThrowForce), _axeConfig.AttackRate);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _abillityUser.SetupAbillity(new WeaponAbillity(_fireballConfig.Weapon, _fireballConfig.ThrowForce), _fireballConfig.AttackRate);
        }
    }
}
