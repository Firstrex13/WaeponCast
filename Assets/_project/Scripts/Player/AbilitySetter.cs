using UnityEngine;

public class AbilitySetter : MonoBehaviour
{
    [SerializeField] private AbillityUser _abillityUser;

    [SerializeField] private Knife _knifePrefab;
    [SerializeField] private Axe _axePrefab;
    [SerializeField] private Fireball _fireballPrefab;

    [SerializeField] private float _knifeThrowForce;
    [SerializeField] private float _axeThrowForce;
    [SerializeField] private float _fireballThrowForce;


    private void Start()
    {
        _abillityUser.SetupAbillity(new WeaponAbillity(_knifePrefab, _knifeThrowForce));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _abillityUser.SetupAbillity(new WeaponAbillity(_knifePrefab, _knifeThrowForce));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _abillityUser.SetupAbillity(new WeaponAbillity(_axePrefab, _axeThrowForce));
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _abillityUser.SetupAbillity(new WeaponAbillity(_fireballPrefab, _fireballThrowForce));
        }
    }
}
