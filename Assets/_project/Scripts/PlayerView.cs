using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerView : MonoBehaviour
{
    private readonly int Running = Animator.StringToHash(nameof(Running));
    private readonly int Hit = Animator.StringToHash(nameof(Hit));
    private readonly int Die = Animator.StringToHash(nameof(Die));


    [SerializeField] private Animator _animator;
    [SerializeField] private HealthViewSmooth _HealthViewSmooth;

    public void PlayRun()
    {
        _animator.SetBool(Running, true);
    }

    public void PlayIdle()
    {
        _animator.SetBool(Running, false);
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
}
