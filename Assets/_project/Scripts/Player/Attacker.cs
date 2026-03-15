using System.Collections;
using UnityEngine;
using Zenject;

public class Attacker : MonoBehaviour
{
    [SerializeField] private UnitChecker _unitChecker;
    [SerializeField] private PlayerAnimations _animations;
    [SerializeField] private AudioSource _throwSound;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private PlayerController _playerController;

    private WaitForSecondsRealtime _delay;
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
            StopCoroutine(_throw);
        }

        _throw = StartCoroutine(Throw());
    }

    private void StopAttack()
    {
        if (_throw != null)
        {
            StopCoroutine(_throw);
        }

        _throw = null;
    }

    private IEnumerator Throw()
    {
        _delay = new WaitForSecondsRealtime(_attackSpeed);

        while (_unitChecker.NearestEnemy)
        {
            if (!_playerController.Moving)
            {
                if (Time.timeScale > 0)
                {
                    _animations.PlayThrow();
                    _throwSound.Play();

                    yield return _delay;
                }
                else
                {
                    yield return _delay;
                }
            }
            else
            {
                yield return _delay;
            }
        }

        _throw = null;
    }
}
