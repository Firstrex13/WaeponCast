using System.Collections;
using UnityEngine;

public class Grenade : Weapon
{
    [SerializeField] private AnimationCurve _yCurve;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _speed;

    private Vector3 _startPosition;
    private float _totalTime;
    private float progress = 0f;

    private void Start()
    {
        _playerPosition = Player.transform;
        _startPosition = transform.position;
        _totalTime = 2f;
        Instantiate(MuzzleParticle, transform.position, Quaternion.identity, transform);
        Instantiate(ProjectileParticle, transform.position, Quaternion.identity, transform);
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        Vector3 target = _playerPosition.position;

        while (enabled)
        {
            progress += Time.deltaTime * _speed;

            Vector3 horizontalPosition = Vector3.Lerp(_startPosition, target, progress);
            float height = _yCurve.Evaluate(progress) * Vector3.Distance(_startPosition, target) * 0.2f;

            Rigidbody.MovePosition(horizontalPosition + Vector3.up * height);
            yield return null;
        }
    }
}
