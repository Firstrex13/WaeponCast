using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAudioManager _audioManager;
    [SerializeField] private PlayerAnimations _animations;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private Mana _mana;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerHealthView _playerHealthView;
    [SerializeField] private ManaBarView _manaBarView;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private AbilityPlayerUser _abilityPlayerUser;

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

    public void InitializePlayer(IProgressService playerProgress, Slider manaSlider, TextMeshProUGUI manaText, Mana mana)
    {
        _mana = mana;
        _health.Initialize(playerProgress);
        _mana.Initialize(playerProgress);
        _playerHealthView.Initialize();
        _manaBarView.Initialize(_mana, manaSlider, manaText);
        _attacker.Initialize(_mana);
        _abilityPlayerUser.Initialize(_mana);
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
