using System.Collections;
using UnityEngine;

public class Grenade : Weapon
{
    [SerializeField] private AnimationCurve _yCurve;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _projectileParticle;
    [SerializeField] private GameObject _muzzleParticle;

    private Vector3 _startPosition;
    private float _totalTime;
    private float progress = 0f;

    private void Start()
    {
        _playerPosition = Player.transform;
        _startPosition = transform.position;
        _totalTime = 2f;
        Instantiate(_muzzleParticle, transform.position, Quaternion.identity, transform);
        Instantiate(_projectileParticle, transform.position, Quaternion.identity, transform);
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        Vector3 target = _playerPosition.position;

        while (enabled)
        {
            progress += Time.deltaTime * _speed;
            float t = Mathf.Clamp01(progress / _totalTime);

            Vector3 horizontalPosition = Vector3.Lerp(_startPosition, target, t);
            float height = _yCurve.Evaluate(t) * Vector3.Distance(_startPosition, target) * 0.2f;

            Rigidbody.MovePosition(horizontalPosition + Vector3.up * height);
            yield return null;
        }
    }
}
