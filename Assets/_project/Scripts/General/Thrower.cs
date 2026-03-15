using UnityEngine;

public class Thrower : MonoBehaviour
{
    [SerializeField] private Knife _knife;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private int _throwSpeed;
    [SerializeField] private UnitChecker _unitChecker;

    public void ThrowWeapon()
    {
        if (_unitChecker.NearestEnemy == null)
        {
            Debug.Log("NoEnemies");
            return;
        }
        Knife knife = Instantiate(_knife, _spawnPosition.position, Quaternion.identity);
        knife.Initialize(_spawnPosition.forward);
        knife.TurnOn();
        knife.GetComponent<Rigidbody>().AddForce(_spawnPosition.transform.forward * _throwSpeed, ForceMode.VelocityChange);
    }
}
