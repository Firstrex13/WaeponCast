using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAudioManager _audioManager;
    [SerializeField] private PlayerAnimations _animations;
    [SerializeField] private Health _health;
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
        _playerController.IsMoving += PlayMove;
        _playerController.IsStopped += PlayIdle;
        _health.Hit += PlayHit;
        _health.Died += PlayDie;
    }

    private void OnDestroy()
    {
        _playerController.IsMoving -= PlayMove;
        _playerController.IsStopped -= PlayIdle;
        _health.Hit -= PlayHit;
        _health.Died -= PlayDie;
    } 

    private void PlayMove()
    {
        _animations.PlayRun();
    }

    private void PlayIdle()
    {
        _animations.PlayIdle();
    }

    private void PlayHit()
    {
        _animations.PlayHit();
        _audioManager.PlayHit();
    }

    private void PlayDie()
    {
        _animations.PlayDie();
    }
}
