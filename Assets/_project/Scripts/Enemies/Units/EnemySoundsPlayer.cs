using UnityEngine;

public class EnemySoundsPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _hitSound;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Hit += PlayHit;
    }

    private void OnDisable()
    {
        _health.Hit -= PlayHit;
    }

    private void PlayHit()
    {
        _hitSound.Play();
    }
}
