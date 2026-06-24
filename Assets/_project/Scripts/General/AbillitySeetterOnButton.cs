
using UnityEngine;
using UnityEngine.UI;

public class AbillitySeetterOnButton : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Material _lightning;
    [SerializeField] private Material _fireball;

    public void SetWeapon(string name)
    {
        switch (name)
        {
            case Weapons.LIGHTNING:
                Weapons.CurrentWeapon = WeaponsList.LIGHTNING;
                _icon.material = _lightning;
                break;
            case Weapons.FIREBALL:
                Weapons.CurrentWeapon = WeaponsList.FIREBALL;
                _icon.material = _fireball;
                break;
            default:
                Weapons.CurrentWeapon = WeaponsList.LIGHTNING;
                break;
        }

        Debug.Log(Weapons.CurrentWeapon);
    }
}
