using UnityEngine;

public class PlayerPresenter
{
    private PlayerView _playerView;
    private Mover _mover;
    private PlayerInput _playerInput;
    private Health _health;

    public PlayerPresenter(PlayerView view, Health health, Mover mover, PlayerInput input)
    {
        _playerView = view;
        _health = health;
        _mover = mover;
        _playerInput = input;
    }

    public void Enable()
    {
        _playerInput.IsMoving += Move;
        _playerInput.IsMoving += Rotate;
        _playerInput.IsMoving += SetRunAnim;
        _playerInput.Stopped += SetIdleAnim;
        _health.Hit += OnHit;
    }

    public void Disable()
    {
        _playerInput.IsMoving -= Move;
        _playerInput.IsMoving -= Rotate;
        _playerInput.IsMoving -= SetRunAnim;
        _playerInput.Stopped -= SetIdleAnim;
        _health.Hit -= OnHit;
    }

    private void Move(Vector3 direction)
    {
        _mover.Move(direction);
    }

    private void Rotate(Vector3 direction)
    {
        _mover.Rotate(direction);
    }

    private void SetRunAnim(Vector3 direction)
    {
        _playerView.PlayRun();
    }

    private void SetIdleAnim()
    {
        _playerView.PlayIdle();
    }

    private void OnHit()
    {
        _playerView.UpdateHealth();
    }
}
