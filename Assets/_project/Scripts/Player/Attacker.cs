using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private UnitChecker _unitChecker;
    [SerializeField] private PlayerAnimations _animations;
    [SerializeField] private AudioSource _throwSound;
    [SerializeField] private float _attackSpeed;

    private WaitForSeconds _delay;
    private Coroutine _throw;

    private void OnEnable()
    {
        _unitChecker.UnitInAttackZone += Attack;
        _unitChecker.NoUnitInAttackZone += StopAttack;
    }

    private void OnDisable()
    {
        _unitChecker.UnitInAttackZone -= Attack;
        _unitChecker.NoUnitInAttackZone -= StopAttack;
    }

    private void Attack()
    {
        if (_throw != null)
        {
            StopCoroutine(Throw());
        }

        StartCoroutine(Throw());
    }

    private void StopAttack()
    {
        if (_throw != null)
        {
            StopCoroutine(Throw());
        }

        _throw = null;
    }

    private IEnumerator Throw()
    {
        _delay = new WaitForSeconds(_attackSpeed);

        while (_unitChecker.NearestEnemy)
        {
            _animations.PlayThrow();
            _throwSound.Play();
            yield return _delay;
        }

        _throw = null;
    }
}
