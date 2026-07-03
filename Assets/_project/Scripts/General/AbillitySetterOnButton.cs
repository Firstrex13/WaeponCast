using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AbillitySetterOnButton : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Material _lightning;
    [SerializeField] private Material _fireball;
    [SerializeField] private GameObject _lightningButton;
    [SerializeField] private GameObject _fireballButton;
    [SerializeField] private GameSaver _saver;

    public PlayerProgress Progress { get; private set; }
    private Weapons Weapons;

    [Inject]
    public void Construct(IProgressService progress)
    {
        Progress = progress.GetProgress();
        Weapons = progress.GetProgress().Weapons;
    }

    private void Start()
    {
        if (Weapons.CurrentWeapon == WeaponsList.LIGHTNING)
        {
            _icon.material = _lightning;
        }
        else if (Weapons.CurrentWeapon == WeaponsList.FIREBALL)
        {
            _icon.material = _fireball;
        }
    }

    public void SetWeapon(string name)
    {
        switch (name)
        {
            case Weapons.LIGHTNING:
                Weapons.CurrentWeapon = WeaponsList.LIGHTNING;
                _icon.material = _lightning;
                _lightningButton.SetActive(false);
                _fireballButton.SetActive(false);
                _saver.SaveGame();
                break;
            case Weapons.FIREBALL:
                Weapons.CurrentWeapon = WeaponsList.FIREBALL;
                _icon.material = _fireball;
                _lightningButton.SetActive(false);
                _fireballButton.SetActive(false);
                _saver.SaveGame();
                break;
            default:
                Weapons.CurrentWeapon = WeaponsList.LIGHTNING;
                break;
        }
    }
}
