using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAudioManager _audioManager;
    [SerializeField] private PlayerAnimations _animations;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private Mana _mana;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerHealthView _playerHealthView;

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

    public void InitializePlayer(IProgressService playerProgress)
    {
        _health.Initialize(playerProgress);
        _mana.Initialize(playerProgress);
        _playerHealthView.Initialize();
    }

    private void PlayHit()
    {
        _animations.PlayHit();
        _audioManager.PlaySound();
        _playerController.StopPlayer();
    }

    private void PlayDie()
    {
        _animations.PlayDie();
        _playerController.MakeDisable();
        Destroy(gameObject, 3);
    }
}
