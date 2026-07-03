using UnityEngine;

public class Trap2 : Trap
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _shootPeriod;
    [SerializeField] private float _shootForce;
    [SerializeField] private TrapProjectile _projectile;

    [SerializeField] private Transform[] _spawnPositions;


    private float _timer;

    private void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);

        _timer += Time.deltaTime;

        if (_timer >= _shootPeriod)
        {
            _timer = 0;

            foreach (Transform position in _spawnPositions)
            {
                TrapProjectile projectile = Instantiate(_projectile, position.position, Quaternion.identity);
                projectile.GetComponent<Rigidbody>().AddRelativeForce(position.forward * _shootForce);
            }
        }
    }
}
