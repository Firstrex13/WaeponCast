using System.Collections;
using UnityEngine;

public class DragonAnimations : MonoBehaviour
{
    private readonly int Run = Animator.StringToHash(nameof(Run));
    private readonly int Hit = Animator.StringToHash(nameof(Hit));
    private readonly int Die = Animator.StringToHash(nameof(Die));
    private readonly int Bite = Animator.StringToHash(nameof(Bite));

    [SerializeField] private Animator _animator;
    [SerializeField] private Health _health;
    public bool CanRun { get; private set; }

    private Coroutine _hitCoroutine;

    private void OnEnable()
    {
        CanRun = true;
        _health.Hit += PlayHit;
        _health.Died += PlayDie;
    }

    private void OnDisable()
    {
        _health.Hit -= PlayHit;
        _health.Died -= PlayDie;
    }

    public void PlayIdle()
    {
        _animator.SetBool(Run, false);
    }

    public void PlayRun()
    {
        _animator.SetBool(Run, true);
    }

    private void PlayDie()
    {
        _animator.SetTrigger(Die);
    }

    private void PlayHit()
    {
        _animator.SetTrigger(Hit);

        if (gameObject.activeSelf)
        {
            if (_hitCoroutine != null)
            {
                StopCoroutine(_hitCoroutine);
            }

            _hitCoroutine = StartCoroutine(InteruptMoving());
        }
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(Bite);

        if (gameObject.activeSelf)
        {
            if (_hitCoroutine != null)
            {
                StopCoroutine(_hitCoroutine);
            }

            _hitCoroutine = StartCoroutine(InteruptMoving());
        }
    }

    private IEnumerator InteruptMoving()
    {
        WaitForSeconds delay = new WaitForSeconds(1);

        CanRun = false;
        yield return delay;
        CanRun = true;
    }
}
