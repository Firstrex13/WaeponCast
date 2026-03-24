using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAudioManager _audioManager;
    [SerializeField] private PlayerAnimations _animations;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private PlayerController _playerController;

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

    private void PlayHit()
    {
        _animations.PlayHit();
        _audioManager.PlayHit();
    }

    private void PlayDie()
    {
        _animations.PlayDie();
        _playerController.MakeDisable();
    }
}
