using UnityEngine;

public class DragonAnimations : MonoBehaviour
{
    private readonly int Run = Animator.StringToHash(nameof(Run));
    private readonly int Hit = Animator.StringToHash(nameof(Hit));
    private readonly int Die = Animator.StringToHash(nameof(Die));
    private readonly int Bite = Animator.StringToHash(nameof(Bite));

    [SerializeField] private Animator _animator;
    [SerializeField] private Health _health;

    private void Start()
    {
        _health.Hit += PlayHit;
        _health.Died += PlayDie;
    }

    private void OnDestroy()
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
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(Bite);
       
    }
}
