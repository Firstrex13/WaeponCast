using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    private readonly int Hit = Animator.StringToHash(nameof(Hit));
    private readonly int Die = Animator.StringToHash(nameof(Die));
    private readonly int Throw = Animator.StringToHash(nameof(Throw));
    private readonly int Velocity = Animator.StringToHash(nameof(Velocity));

    [SerializeField] private Animator _animator;
    [SerializeField] private HealthViewSmooth _HealthViewSmooth;

    public void PlayMove(float velocity)
    {
        _animator.SetFloat(Velocity, velocity);
    }

    public void UpdateHealth()
    {
        _HealthViewSmooth.UpdateValue();
    }

    public void PlayHit()
    {
        _animator.SetTrigger(Hit);
    }

    public void PlayDie()
    {
        _animator.SetTrigger(Die);
    }

    public void PlayThrow()
    {
        _animator.SetTrigger(Throw);
    }
}
