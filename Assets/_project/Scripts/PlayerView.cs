using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private HealthViewSmooth _HealthViewSmooth;

    public void PlayRun()
    {
        _animator.SetBool("IsRunning", true);
    }

    public void PlayIdle()
    {
        _animator.SetBool("IsRunning", false);
    }

    public void UpdateHealth()
    {
        _HealthViewSmooth.UpdateValue();
    }
}
